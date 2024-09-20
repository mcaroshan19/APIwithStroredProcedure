using BlogPostAngularApi.Server.Model;
using Microsoft.AspNetCore.Mvc;
// For IEnumerable
using System.Data;
using System.Data.SqlClient; // Add this using directive

namespace BlogPostAngularApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SqlConnection _con;

        // Constructor to initialize the SqlConnection via dependency injection
        public ValuesController(SqlConnection con)
        {
            _con = con;
        }

        Employee emp = new Employee();

        // GET: api/<ValuesController>
        [HttpGet]
        //public List<Employee> Get()
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("usp_GetallEmployee", _con);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<Employee> lstEmployee = new List<Employee>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Employee emp = new Employee();
        //            emp.Name = dt.Rows[i]["Name"].ToString();
        //            emp.ID= Convert.ToInt32(dt.Rows[i]["ID"]);
        //            emp.Age= Convert.ToInt32(dt.Rows[i]["Age"]);
        //            emp.Active = Convert.ToInt32(dt.Rows[i]["Active"]);


        //            lstEmployee.Add(emp);

        //        }
        //    }
        //    if (lstEmployee.Count > 0)
        //    {
        //        return lstEmployee;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}


        public List<Employee> Get()
        {
            List<Employee> lstEmployee = new List<Employee>();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("usp_GetallEmployee", _con)) 
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Employee emp = new Employee
                        {
                            ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                            Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty,
                            Age = row["Age"] != DBNull.Value ? Convert.ToInt32(row["Age"]) : 0,
                            Active = row["Active"] != DBNull.Value ? Convert.ToInt32(row["Active"]) : 0,
                            Department = new Department
                            {
                                DepartmentID = row["DepartmentID"] != DBNull.Value ? Convert.ToInt32(row["DepartmentID"]) : 0,
                                DepartmentName = row["DepartmentName"] != DBNull.Value ? row["DepartmentName"].ToString() : string.Empty
                            }
                        };

                        lstEmployee.Add(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("An error occurred while retrieving employee data.", ex);
            }

            return lstEmployee;
        }




        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetEmployeeById", _con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee emp = new Employee();
            if (dt.Rows.Count > 0)
            {
               
                
                  
                    emp.Name = dt.Rows[0]["Name"].ToString();
                    emp.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    emp.Age = Convert.ToInt32(dt.Rows[0]["Age"]);
                    emp.Active = Convert.ToInt32(dt.Rows[0]["Active"]);
                   

                
            }
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post(Employee employee)
        {
            string msg = "";
            if(employee !=null)
            {
                SqlCommand cmd = new SqlCommand("usp_AddEmployee", _con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Active", employee.Active);
                cmd.Parameters.AddWithValue("@DepartmentName", employee.Department?.DepartmentName ?? (object)DBNull.Value);

                _con.Open();
                int i=cmd.ExecuteNonQuery();
                _con.Close();
                if(i>0)
                {
                    msg ="Data has been Inserted";
                }
                else
                {
                    msg= "Error";
                }
            }
            return msg;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public string Put(int id, Employee employee)
        {
            string msg = "";
            if (employee != null)
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateEmployee", _con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Active", employee.Active);

                _con.Open();
                int i = cmd.ExecuteNonQuery();
                _con.Close();
                if (i > 0)
                {
                    msg = "Data has been Inserted";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = "";
            
                SqlCommand cmd = new SqlCommand("usp_DeleteEmployee", _con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
               

                _con.Open();
                int i = cmd.ExecuteNonQuery();
                _con.Close();
                if (i > 0)
                {
                    msg = "Data has been Deleted";
                }
                else
                {
                    msg = "Error";
                }
            
            return msg;
        }
    }
}
