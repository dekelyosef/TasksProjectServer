using System.Data;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using TasksProjectServer.Models.Request;

namespace TasksProjectServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlConnection _conn;

        public TasksController(IConfiguration configuration)
        {
                _configuration = configuration;
                _conn = new MySqlConnection(_configuration.GetConnectionString("connectionString"));
        }

        [Route("GetTasks")]
        [HttpPost]
        public JsonResult GetTasks(GetTasksRequest request)
        {
            var cmd = new MySqlCommand
            {
                Connection = _conn,
                CommandText = "getTasks"
            };

            cmd.Parameters.Add(GetParameter("p_status", MySqlDbType.VarChar, request.Status));
            cmd.Parameters.Add(GetParameter("p_date_start", MySqlDbType.DateTime, request.StartDate));
            cmd.Parameters.Add(GetParameter("p_date_end", MySqlDbType.DateTime, request.EndDate));
            cmd.Parameters.Add(GetParameter("p_order", MySqlDbType.VarChar, request.Order));
            return new JsonResult(ExecSpQuery(cmd));
        }

        [Route("GetTask")]
        [HttpPost]
        public JsonResult GetTask(GetTaskRequest request)
        {
            var cmd = new MySqlCommand
            {
                Connection = _conn,
                CommandText = "getTask"
            };

            cmd.Parameters.Add(GetParameter("p_id", MySqlDbType.Int32, request.Id));
            return new JsonResult(ExecSpQuery(cmd));
        }

        [Route("AddNewTask")]
        [HttpPost]
        public void AddNewTask(AddNewTaskRequest request)
        {
            var cmd = new MySqlCommand
            {
                Connection = _conn,
                CommandText = "addNewTask"
            };

            cmd.Parameters.Add(GetParameter("p_id", MySqlDbType.Int32, request.Id));
            cmd.Parameters.Add(GetParameter("p_title", MySqlDbType.VarChar, request.Title));
            cmd.Parameters.Add(GetParameter("p_date", MySqlDbType.DateTime, request.Date));
            cmd.Parameters.Add(GetParameter("p_description", MySqlDbType.VarChar, request.Description));
            cmd.Parameters.Add(GetParameter("p_status", MySqlDbType.VarChar, request.Status));
            ExecSpQuery(cmd);
        }

        [Route("DeleteTask")]
        [HttpPost]
        public void DeleteTask(DeleteTaskRequest request)
        {
            var cmd = new MySqlCommand
            {
                Connection = _conn,
                CommandText = "deleteTask"
            };

            cmd.Parameters.Add(GetParameter("p_id", MySqlDbType.Int32, request.Id));
            ExecSpQuery(cmd);
        }

        [Route("EditTask")]
        [HttpPost]
        public void EditTask(EditTaskRequest request)
        {
            var cmd = new MySqlCommand
            {
                Connection = _conn,
                CommandText = "editTask"
            };

            cmd.Parameters.Add(GetParameter("p_id", MySqlDbType.Int32, request.Id));
            cmd.Parameters.Add(GetParameter("p_title", MySqlDbType.VarChar, request.Title));
            cmd.Parameters.Add(GetParameter("p_date", MySqlDbType.DateTime, request.Date));
            cmd.Parameters.Add(GetParameter("p_description", MySqlDbType.VarChar, request.Description));
            cmd.Parameters.Add(GetParameter("p_status", MySqlDbType.VarChar, request.Status));
            ExecSpQuery(cmd);
        }

        [Route("EditTaskStatus")]
        [HttpPost]
        public void EditTaskStatus(EditTaskStatusRequest request)
        {
            var cmd = new MySqlCommand
            {
                Connection = _conn,
                CommandText = "editTaskStatus"
            };

            cmd.Parameters.Add(GetParameter("p_id", MySqlDbType.Int32, request.Id));
            cmd.Parameters.Add(GetParameter("p_status", MySqlDbType.VarChar, request.Status));
            ExecSpQuery(cmd);
        }

        public DataSet ExecSpQuery(MySqlCommand cmd)
        {
            var retval = new DataSet();
            var outParam = new MySqlParameter();
            cmd.CommandType = CommandType.StoredProcedure;
            outParam.ParameterName = "p_RETVAL";
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(retval);
            return retval;
        }

        public MySqlParameter GetParameter(string paramName, MySqlDbType paramType
            , object paramValue)
        {
            return new MySqlParameter
            {
                ParameterName = paramName,
                MySqlDbType = paramType,
                Value = paramValue
            };
        }


    }
}