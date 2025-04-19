using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using NagruzkaClg.Model.Entities;
using NagruzkaClg.ViewModels;

namespace NagruzkaClg.Controllers;

public class SpecializeController
{
    private readonly AppDbContext _context;

    public SpecializeController(AppDbContext context)
    {
        _context = context;
    }
   public async Task CreateSpecializeAsync(Specialize specialize)
        {
            try
            {
                await _context.Specializes.AddAsync(specialize);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании специальности", e);
            }
        }

        public async Task DeleteSpecializeByIdAsync(int id)
        {
            try
            {
                var specialize = await _context.Specializes.FindAsync(id);
                if (specialize == null)
                {
                    throw new KeyNotFoundException($"Специальность с ID {id} не найдена");
                }

                _context.Specializes.Remove(specialize);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при удалении специальности", e);
            }
        }

        public async Task UpdateSpecializeAsync(
            int id,
            string name,
            ICollection<Groups> groups,
            ICollection<Plan> plans)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Неверный идентификатор специальности", nameof(id));
            }

            try
            {
                var specialize = await _context.Specializes
                    .Include(s => s.Groups)
                    .Include(s => s.Plans)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (specialize == null)
                {
                    throw new KeyNotFoundException($"Специальность с ID {id} не найдена");
                }

                specialize.Name = name;
                
                specialize.Groups.Clear();
                foreach (var group in groups)
                {
                    
                    var existingGroup = await _context.Groups.FindAsync(group.Id);
                    if (existingGroup != null)
                    {
                        specialize.Groups.Add(existingGroup);
                    }
                    else
                    {
                        
                        specialize.Groups.Add(group);
                    }
                }

                
                specialize.Plans.Clear();
                foreach (var plan in plans)
                {
                    var existingPlan = await _context.Plan.FindAsync(plan.Id);
                    if (existingPlan != null)
                    {
                        specialize.Plans.Add(existingPlan);
                    }
                    else
                    {
                        specialize.Plans.Add(plan);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении специальности в базе данных", ex);
            }
        }

        public async Task<List<DisciplineHoursResult>> GetDisciplineHoursBySpecializeAsync(int specializeId)
        {
            try
            {
                var result = await _context.Plan
                    .Where(p => p.Specialize.Id == specializeId)
                    .SelectMany(p => p.Nagruzki)
                    .GroupBy(n => new { n.Discipline.Id, n.Discipline.Title })
                    .Select(g => new DisciplineHoursResult
                    {
                        DisciplineId = g.Key.Id,
                        DisciplineTitle = g.Key.Title,
                        TheoryHours = g.Sum(n => n.Plan.TeoryHours),
                        PracticeHours = g.Sum(n => n.Plan.PracticeHours),
                        SelfHours = g.Sum(n => n.Plan.SelfHours),
                        KursHours = g.Sum(n => n.Plan.KursHours),
                        TotalHours = g.Sum(n =>
                            n.Plan.TeoryHours + n.Plan.PracticeHours + n.Plan.SelfHours + n.Plan.KursHours)
                    })
                    .OrderBy(d => d.DisciplineTitle)
                    .AsNoTracking()
                    .ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении списка специальностей", e);
            }
        }

        public async Task<List<Specialize>> GetAllSpecializesAsync()
        {
            return await _context.Specializes.ToListAsync();
        }

        public async Task<Specialize?> GetSpecializeByIdAsync(int id, bool includeDetails = false)
        {
            try
            {
                if (includeDetails)
                {
                    return await _context.Specializes
                        .AsSplitQuery()
                        .AsNoTracking()
                        .Include(s => s.Groups)
                        .Include(s => s.Plans)
                        .FirstOrDefaultAsync(s => s.Id == id);
                }
                else
                {
                    return await _context.Specializes.FindAsync(id);
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении специальности по ID", e);
            }
        }
    }


