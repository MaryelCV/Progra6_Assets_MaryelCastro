using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Progra6_Assets_MaryelCastro.Models;
using Progra6_Assets_MaryelCastro.ModelsDTOs;

namespace Progra6_Assets_MaryelCastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Progra620241Context _context;

        public UsersController(Progra620241Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        //Get
        //Este get permite obtener los datos puntales de un usuario usuando el correo como parametro

        // GET:  api/Users/GetUserData?pUserName=algo
        [HttpGet("GetUserData")]
         public ActionResult<IEnumerable<UserDTO>> GetUserData(string pUserName)
        {
            //El proposito de usar el DTO es combinar aca los datos de las tablas 
            //user y userrole y devolver un solo objeto json con dicha informacion
            //ademas no se sabra como se llaman los atributos originales.

            //para hacer esra consulta NO usares procedimientos almacenados como en progra 5, si no que usaremos 
            //LINQ, que permite hacer consultas sobre 
            //colecciones directamente en la progra
             var query = (from us in _context.Users
                          join ur in _context.UserRoles on us.UserRoleId equals ur.UserRoleId
                          where us.UserName == pUserName && us.Active == true
                          select  new
                          {
                              idUsuaio = us.UserId,
                              cedula = us.CardId,
                              nombre = us.FirstName,
                              apellidos = us.LastName,
                              telefono = us.PhoneNumber,
                              direccion = us.Address,
                              correo = us.UserName,
                              activo = us.Active,
                              idrol = ur.UserRoleId,
                              rol = ur.UserRoleDescription
                          }
                            ).ToList();

            //Ahora que tenemos el resultado de la consulta en la variable query, procedemos a crear el
            //resultado de la funcion. El resultado tiene que ser tipo UserDTO

            //Crear el objeto de respuesta
            List<UserDTO> listausuarios = new List<UserDTO>();

            //Ahora hacemos un recorrido de las posibles iteracion de la variable
            //query y llenamos en cada una de ellas un nuevo objeto DTO.

            foreach (var item in query)
            {
                UserDTO newUser = new UserDTO()
                {
                    CodigoUsuario = item.idUsuaio,
                    Cedula = item.cedula,
                    Nombre = item.nombre,
                    Apellidos = item.apellidos,
                    Telefono = item.telefono,
                    Direccion = item.direccion,
                    Correo = item.correo,
                    Activo = item.activo,
                    CodigoDeRol = item.idrol,
                    RolDeUsuario = item.rol,
                    NotasDelUsuario = "No hay comentarios"
                };

                listausuarios.Add(newUser);
            }

            if (listausuarios == null || listausuarios.Count() == 0)
            {
                return NotFound();
            }

            return listausuarios;
        }




        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
