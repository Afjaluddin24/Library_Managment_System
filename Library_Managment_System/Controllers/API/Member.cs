using Library_Managment_System.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Member : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public Member(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("AddMember")]
        public async Task<IActionResult> AddMember(Library_Managment_System.Models.Members member)
        {
            try
            {
                var Data = await _dbcontext.Members.Where(o => o.name == member.name).FirstOrDefaultAsync();
                if (Data == null)
                {
                    _dbcontext.Members.Add(member);
                    await _dbcontext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Member Add Successfully!" });
                }
                else
                {
                    return Ok(new { Status = "Faile", Result = "Please try again" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Faile", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("MemberList")]
        public async Task<IActionResult> MemberList()
        {
            try
            {
                var Data = await _dbcontext.Members.ToListAsync();
                return Ok(new { Status = "Ok", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Faile", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("Member/{member_id?}")]
        public async Task<IActionResult> getMember(int member_id)
        {
            try
            {
                var Data = await _dbcontext.Members.Where(o => o.member_id == member_id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Faile", Result = "Data Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Faile", Result = ex.Message });
            }
        }

        [HttpPost]
        [Route("UpdateMember")]
        public async Task<IActionResult> UpdateMember(Library_Managment_System.Models.Members member)
        {
            try
            {
                _dbcontext.Members.Update(member);
                await _dbcontext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Member Update Successfully!" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Faile", Result = ex.Message });
            }
        }
    }
}
