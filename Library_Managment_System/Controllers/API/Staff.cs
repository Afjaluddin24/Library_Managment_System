using Library_Managment_System.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Staff : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public Staff(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("AddStaff")]
        public async Task<IActionResult> AddStaff(Library_Managment_System.Models.Staff staff)
        {
            try
            {
                var Data = await _dbcontext.Staffs.Where(o => o.email == staff.email).FirstOrDefaultAsync();
                if (Data == null)
                {
                    _dbcontext.Staffs.Add(staff);
                    await _dbcontext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Staff add Successfully." });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Staff email already exists." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("Stafflist")]
        public async Task<IActionResult> Stafflist()
        {
            try
            {
                var Data = await _dbcontext.Staffs.ToListAsync();
                return Ok(new { Status = "Ok", Result = Data });
                //if (Data.Count > 0)
                //{
                //    return Ok(new { Status = "Ok", Result = Data });
                //}
                //else
                //{
                //    return Ok(new { Status = "Fail", Result = "No Staff Found." });
                //}
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }

        }
        [HttpGet]
        [Route("StaffDetals/{staff_id?}")]
        public async Task<IActionResult> StaffDetals(int staff_id)
        {
            try
            {
                var Data = await _dbcontext.Staffs.Where(o => o.staff_id == staff_id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "No Staff Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }

        }

        [HttpPost]
        [Route("UpdateStaff")]
        public async Task<IActionResult> UpdateStaff(Library_Managment_System.Models.Staff staff)
        {
            try
            {
                _dbcontext.Staffs.Update(staff);
                await _dbcontext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Staff Update Successfully." });

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
    }
}
