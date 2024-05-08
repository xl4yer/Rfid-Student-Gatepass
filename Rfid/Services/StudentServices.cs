using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Rfid.Class;
using Rfid.Models;
using System.Data;

namespace Rfid.Services
{
    public class StudentServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;


        public StudentServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }

        public async Task<List<students>> Students()
        {
            List<students> xstud = new List<students>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewStudent", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xstud.Add(new students
                        {
                            studID = rdr["studID"].ToString(),
                            photo = (byte[])rdr["photo"],
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            gender = rdr["gender"].ToString(),
                            gradelvl = rdr["gradelvl"].ToString(),
                            address = rdr["address"].ToString(),
                            contact = rdr["contact"].ToString(),
                            guardian = rdr["guardian"].ToString(),
                            gcontact = rdr["gcontact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return xstud;
        }

        public async Task<int> AddStudent(students xstud)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddStudent", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_studID", xstud.studID);
                    com.Parameters.AddWithValue("_photo", xstud.photo);
                    com.Parameters.AddWithValue("_fname", xstud.fname);
                    com.Parameters.AddWithValue("_mname", xstud.mname);
                    com.Parameters.AddWithValue("_lname", xstud.lname);
                    com.Parameters.AddWithValue("_bdate", xstud.bdate);
                    com.Parameters.AddWithValue("_gender", xstud.gender);
                    com.Parameters.AddWithValue("_gradelvl", xstud.gradelvl);
                    com.Parameters.AddWithValue("_address", xstud.address);
                    com.Parameters.AddWithValue("_contact", xstud.contact);
                    com.Parameters.AddWithValue("_guardian", xstud.guardian);
                    com.Parameters.AddWithValue("_gcontact", xstud.gcontact);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return 0;
        }

        public async Task<int> UpdateStudent(students xstud)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("UpdateStudent", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_studID", xstud.studID);
                    com.Parameters.AddWithValue("_photo", xstud.photo);
                    com.Parameters.AddWithValue("_fname", xstud.fname);
                    com.Parameters.AddWithValue("_mname", xstud.mname);
                    com.Parameters.AddWithValue("_lname", xstud.lname);
                    com.Parameters.AddWithValue("_bdate", xstud.bdate);
                    com.Parameters.AddWithValue("_gender", xstud.gender);
                    com.Parameters.AddWithValue("_gradelvl", xstud.gradelvl);
                    com.Parameters.AddWithValue("_address", xstud.address);
                    com.Parameters.AddWithValue("_contact", xstud.contact);
                    com.Parameters.AddWithValue("_guardian", xstud.guardian);
                    com.Parameters.AddWithValue("_gcontact", xstud.gcontact);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return 0;
        }

        public async Task<List<students>> SearchStudent(string search)
        {
            List<students> xstud = new List<students>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchStudent", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", search);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xstud.Add(new students
                        {
                            studID = rdr["studID"].ToString(),
                            photo = (byte[])rdr["photo"],
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            gender = rdr["gender"].ToString(),
                            gradelvl = rdr["gradelvl"].ToString(),
                            address = rdr["address"].ToString(),
                            contact = rdr["contact"].ToString(),
                            guardian = rdr["guardian"].ToString(),
                            gcontact = rdr["gcontact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return xstud;
        }

        public async Task<int> CountStudents()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountStudents", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }


        public async Task<List<students>> SearchStudID(string search)
        {
            List<students> xstud = new List<students>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchStudID", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("_search", search);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xstud.Add(new students
                        {
                            studID = rdr["studID"].ToString(),
                            photo = (byte[])rdr["photo"],
                            fname = rdr["fname"].ToString(),
                            mname = rdr["mname"].ToString(),
                            lname = rdr["lname"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            gender = rdr["gender"].ToString(),
                            gradelvl = rdr["gradelvl"].ToString(),
                            address = rdr["address"].ToString(),
                            contact = rdr["contact"].ToString(),
                            guardian = rdr["guardian"].ToString(),
                            gcontact = rdr["gcontact"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return xstud;
        }
    }
}

