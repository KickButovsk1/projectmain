using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using NagruzkaClg;
using NagruzkaClg.Model;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.Controllers;

public class GroupsController
{
    private readonly AppDbContext _context;

    public GroupsController(AppDbContext context)
    {
        _context = context;
    }

        public async Task CreateGroupAsync(Groups group)
        {
            try
            {
                await _context.Groups.AddAsync(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании группы", e);
            }
        }

        public async Task DeleteGroupByIdAsync(int id)
        {
            try
            {
                var group = await _context.Groups.FindAsync(id);
                if (group == null)
                {
                    throw new KeyNotFoundException($"Группа с ID {id} не найдена");
                }
            

                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при удалении группы", e);
            }
        }

        public async Task UpdateGroupAsync(
            int id,
            string name,
            int specializeId,
            int freeOrSpendId,
            int obuchenieFormId,
            int courseId,
            ICollection<Nagruzka> nagruzki)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Неверный идентификатор группы", nameof(id));
            }

            try
            {
                var group = await _context.Groups
                    .AsSplitQuery()
                    .Include(g => g.Specialize)
                    .Include(g => g.FreeOrSpend)
                    .Include(g => g.ObuchenieForm)
                    .Include(g => g.Course)
                    .Include(g => g.Nagruzka)
                    .FirstOrDefaultAsync(g => g.Id == id);

                if (group == null)
                {
                    throw new KeyNotFoundException($"Группа с ID {id} не найдена");
                }

                group.Name = name;
                group.Specialize.Id = specializeId;
                group.FreeOrSpend.Id = freeOrSpendId;
                group.ObuchenieForm.Id = obuchenieFormId;
                group.Course.Id = courseId;
                
                
                group.Nagruzka.Clear();
                foreach (var nagruzka in nagruzki)
                {
                    group.Nagruzka.Add(nagruzka);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении группы в базе данных", ex);
            }
        }

        public async Task<IEnumerable<Groups>> GetAllGroupsAsync()
        {
            try
            {
                return await _context.Groups
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Include(x => x.Specialize)
                    .Include(x => x.FreeOrSpend)
                    .Include(x => x.ObuchenieForm)
                    .Include(x => x.Course)
                    .Include(x => x.Nagruzka)
                    .OrderBy(x => x.Name)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении всех групп", e);
            }
        }

        public async Task<Groups?> GetGroupByIdAsync(int id)
        {
            try
            {
                return await _context.Groups
                    .AsNoTracking()
                    .AsSingleQuery()
                    .Include(x => x.Specialize)
                    .Include(x => x.FreeOrSpend)
                    .Include(x => x.ObuchenieForm)
                    .Include(x => x.Course)
                    .Include(x => x.Nagruzka)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении группы по ID", e);
            }
        }
    }

