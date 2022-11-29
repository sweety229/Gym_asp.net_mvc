using GymProjectMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GymProjectMvc.Dal
{
    public class GymDal
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        public int insertMember(GymModel gymmodels)
        {
            try
            {
                string sql = "insert into gymproject(membername,contact,email,startdate,address,city)values('" + gymmodels.memberName + "','" + gymmodels.Contact + "','" + gymmodels.emailId + "','" + gymmodels.startdate + "','" + gymmodels.Address + "','" + gymmodels.City + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int status = cmd.ExecuteNonQuery();
                if(status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

      public List<GymModel> getMemberList()
        {
            List<GymModel> members = new List<GymModel>();

            try
            {
                conn.Open();
                using(SqlCommand cmd1 = new SqlCommand("select id,membername,contact,email,startdate,address,city from gymproject",conn))
                {
                    cmd1.CommandType = CommandType.Text;

                    using(SqlDataAdapter sda= new SqlDataAdapter(cmd1))
                    {
                        using(DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach(DataRow dr in dt.Rows)
                            {
                                GymModel gym = new GymModel();
                                gym.id = Convert.ToInt32(dr[0].ToString());
                                gym.memberName = dr[1].ToString();
                                gym.Contact = Convert.ToInt32(dr[2].ToString());
                                gym.emailId = dr[3].ToString();
                                gym.startdate = dr[4].ToString();
                                gym.Address = dr[5].ToString();
                                gym.City = dr[6].ToString();

                                members.Add(gym);
                            }
                        }
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return members;
        }

        public List<GymModel> getById(string id)
        {
            List<GymModel> members = new List<GymModel>();
            try
            {
                conn.Open();

                using(SqlCommand cmd1 = new SqlCommand("select id,membername,contact,email,startdate,address,city from gymproject where id ='"+id+"'",conn))
                {
                    cmd1.CommandType = CommandType.Text;
                    using(SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using(DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                                
                            foreach(DataRow dr in dt.Rows)
                            {
                                GymModel gym = new GymModel();
                                gym.id = Convert.ToInt32(dr[0].ToString());
                                gym.memberName = dr[1].ToString();
                                gym.Contact = Convert.ToInt32(dr[2].ToString());
                                gym.emailId = dr[3].ToString();
                                gym.startdate = dr[4].ToString();
                                gym.Address = dr[5].ToString();
                                gym.City = dr[6].ToString();

                                members.Add(gym);
                            }
                        }
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
            return members;
        }


        public int UpdateMember(GymModel gymmodels)
        {
            try
            {
                string sql = "update gymproject set memberName = '" + gymmodels.memberName + "', contact = '" + gymmodels.Contact + "', email = '" + gymmodels.emailId + "', startdate = '" + gymmodels.startdate+ "', address = '" + gymmodels.Address + "', city = '" + gymmodels.City + "' where id = '" + gymmodels.id + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return 0;

        }

         public int delete(string id)
        {
            try
            {
                string sql = "delete from gymproject where id = '"+id+"'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int status = cmd.ExecuteNonQuery();
                if(status>0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

    }
}