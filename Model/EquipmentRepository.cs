using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCurd.Model
{

    public class EquipmentDapperFactory
    { }

    public class EquipmentRepository
    {
        private string connectionstring;

        public EquipmentRepository()
        {
            connectionstring = @"Data Source=192.168.16.138\SQLEXPRESS;Initial Catalog=equipmentDb;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionstring);

            }
        }

        public void Add(Equipments equip)
        {
            using (IDbConnection dbConnection = Connection)
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Equipments"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Equipments> GetAll()

        {
            List<Equipments> EquipmentList = new List<Equipments>();
            using (IDbConnection dbConnection = Connection)
            {
                {
                   
                    dbConnection.Open();
                    //EquipmentList=dbConnection.Query<Equipments>("sp_Get_All_Equipment_Detail").ToList();
                    EquipmentList = dbConnection.Query<Equipments>("sp_Get_All_Equipment_Detail", null, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
                }
                return EquipmentList;

                

            }

        }
        public Equipments GetById(int? id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@EquipmentID", id);
                //string sQuery = @"select * from Equipments where EquipmentID=@Id";
                dbConnection.Open();
                return dbConnection.Query<Equipments>("sp_Get_EquipmentsById", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                //DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("@Id", id);
                //groupMeeting = con.Query<GroupMeeting>("GetGroupMeetingByID", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault(

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {

                string sQuery = @"Delete from Equipments where EquipmentID=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });

            }
        }

        public int Update(Equipments equipment)
        {
            {
                int rowAffected = 0;

                using (IDbConnection dbConnection = Connection)
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@EquipmentID", equipment.EquipmentID);
                    parameters.Add("@EquipmentCode", equipment.EquipmentCode);
                    parameters.Add("@CategoryID", equipment.CategoryID);
                    parameters.Add("@SubCategoryID", equipment.SubCategoryID);
                    parameters.Add("@MaintPerodicityID", equipment.MaintPerodicityID);
                    parameters.Add("@UnitLookupID", equipment.UnitLookupID);
                    parameters.Add("@Specifications", equipment.Specifications);
                    parameters.Add("@DepartmentID", equipment.DepartmentID);
                    parameters.Add("@DateOfPurchase", equipment.DateOfPurchase);
                    parameters.Add("@CostOfEquipment", equipment.CostOfEquipment);
                    parameters.Add("@SupplierID", equipment.SupplierID);
                    parameters.Add("@StatusID", equipment.StatusID);
                    parameters.Add("@Remarks", equipment.Remarks);
                    parameters.Add("@IsActive", equipment.IsActive);
                    parameters.Add("@CreatedDate", equipment.CreatedDate);
                    parameters.Add("@UpdatedDate", equipment.UpdatedDate);
                    parameters.Add("@CreatedBy", equipment.CreatedDate);
                    parameters.Add("@UpdatedBy", equipment.CreatedBy);
                   rowAffected = dbConnection.Execute("sp_Update_Equipments", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }

        }
            
    }
    }
    

