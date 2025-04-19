using Microsoft.EntityFrameworkCore;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.Controllers;

public class TeacherController
{
    private readonly AppDbContext _context;

    public TeacherController(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateTeacherAsync(Teachers teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
            
            
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при создании преподователя");
            }
        }

        public async Task DeleteTeacherByIdAsync(int id)
        {
            try
            {
                var teacher = await _context.Teachers.FindAsync(id);
                if (teacher == null)
                {
                    throw new KeyNotFoundException($"Преподователь с ID {id} не найден");
                }

                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            { 
                throw new Exception();
            }
            
        }

      public async Task UpdateTeacherAsync(
            int id,
            string name,
            string secondName,
            string lastName,
            string image,
            ICollection<Load> loads,
            ICollection<Nagruzka> nagruzki)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Неверный идентификатор преподавателя", nameof(id));
            }

            try
            {
                var existingTeacher = await _context.Teachers
                    .Include(t => t.Loads)
                    .Include(t => t.Nagruzki)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (existingTeacher == null)
                {
                    throw new KeyNotFoundException($"Преподаватель с ID {id} не найден");
                }

                existingTeacher.Name = name;
                existingTeacher.SecondName = secondName;
                existingTeacher.LastName = lastName;
                existingTeacher.Image = image;
               
                
                existingTeacher.Loads.Clear();
                foreach (var load in loads)
                {
                    
                    var existingLoad = await _context.Load.FindAsync(load.Id) ?? load;
                    existingTeacher.Loads.Add(existingLoad);
                }

                
                existingTeacher.Nagruzki.Clear();
                foreach (var nagruzka in nagruzki)
                {
                    var existingNagruzka = await _context.Nagruzka.FindAsync(nagruzka.Id) ?? nagruzka;
                    existingTeacher.Nagruzki.Add(existingNagruzka);
                }


                _context.Teachers.Update(existingTeacher);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении преподавателя в базе данных", ex);
            }
        }

        public async Task<IEnumerable<Teachers>> GetAllTeachersAsync()
        {
            try
            {
                return await _context.Teachers
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Include(t => t.Loads)
                    .Include(t => t.Nagruzki)
                    .OrderBy(t => t.Name)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении всех преподавателей", e);
            }
        }
/// <summary>
/// ??
/// </summary>
/// <param name="id"></param>
/// <param name="includeDetails"></param>
/// <returns></returns>
/// <exception cref="KeyNotFoundException"></exception>
/// <exception cref="Exception"></exception>
        public async Task<Teachers> GetTeacherByIdAsync(int id, bool includeDetails = false)
        {
            try
            {
                var query = _context.Teachers.Where(t => t.Id == id);

                if (includeDetails)
                {
                    query = query
                        .Include(t => t.Loads)
                        .Include(t => t.Nagruzki);
                }

                var teacher = await query
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x=>x.Id==id);

                if (teacher == null)
                {
                    throw new KeyNotFoundException($"Преподаватель с ID {id} не найден");
                }

                return teacher;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении преподавателя по ID", e);
            }
        }
    }
