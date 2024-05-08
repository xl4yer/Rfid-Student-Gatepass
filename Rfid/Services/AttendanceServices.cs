using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
using Rfid.Class;
using Rfid.Models;
using System.Data;

namespace Rfid.Services
{
    public class AttendanceServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;


        public AttendanceServices(AppDb constring, IConfiguration configuration)
        {
            _constring = constring;
            Configuration = configuration;
        }

        public async Task<List<attendance>> Attendance()
        {
            List<attendance> xsub = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("ViewAttendance", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xsub.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null : 
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null : 
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),
                            photo = (byte[])rdr["photo"],
                            gradelvl = rdr["gradelvl"].ToString()
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

            return xsub;
        }

        public async Task<List<attendance>> TAttendance()
        {
            List<attendance> xsub = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("TAttendance", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xsub.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),
                            photo = (byte[])rdr["photo"],
                            gradelvl = rdr["gradelvl"].ToString()
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

            return xsub;
        }

        public async Task<List<attendance>> SearchAttendance(string search)
        {
            List<attendance> xsub = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("SearchAttendance", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", search);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xsub.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),
                            photo = (byte[])rdr["photo"],
                            gradelvl = rdr["gradelvl"].ToString()
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

            return xsub;
        }

        public async Task<List<attendance>> SAttendanceDate(string search)
        {
            List<attendance> xsub = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("SAttendanceDate", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xsub.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),
                            photo = (byte[])rdr["photo"],
                            gradelvl = rdr["gradelvl"].ToString()
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

            return xsub;
        }

        public async Task<List<attendance>> TimeIn()
        {
            List<attendance> xsub = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("TimeIn", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xsub.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),
                            photo = (byte[])rdr["photo"],
                            gradelvl = rdr["gradelvl"].ToString()
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

            return xsub;
        }

        public async Task<List<attendance>> TimeOut()
        {
            List<attendance> xsub = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("TimeOut", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        xsub.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            fullname = rdr["fullname"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),
                            photo = (byte[])rdr["photo"],
                            gradelvl = rdr["gradelvl"].ToString()
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

            return xsub;
        }

        public async Task<int> AddAttendance(attendance xattendance)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddAttendance", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("p_studID", xattendance.studID);
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

        public async Task<int> UpdateAttendance(attendance xattendance)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("UpdateAttendance", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("p_studID", xattendance.studID);
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

        public async Task<List<attendance>> CheckTimeIN(string _studID, DateTime _timeIN)
        {
            List<attendance> x = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("CheckTimeIN", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("_studID", _studID);
                    com.Parameters.AddWithValue("_timeIN", _timeIN);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        x.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),

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

            return x;
        }

        public async Task<int> CountTimeIn()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountTimeIn", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

		public async Task<int> InJanuary()
		{
			using (var con = new MySqlConnection(_constring.GetConnection()))
			{
				await con.OpenAsync().ConfigureAwait(false);
				var com = new MySqlCommand("InJanuary", con)
				{
					CommandType = CommandType.StoredProcedure,
				};
				return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
			}
		}

        public async Task<int> InFebruary()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InFebruary", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InMarch()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InMarch", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InApril()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InApril", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InMay()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InMay", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InJune()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InJune", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InJuly()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InJuly", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InAugust()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InAugust", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InSeptember()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InSeptember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InOctober()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InOctober", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InNovember()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InNovember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> InDecember()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("InDecember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutJanuary()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutJanuary", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutFebruary()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutFebruary", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutMarch()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutMarch", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutApril()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutApril", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        // Add similar methods for the remaining months (May to December)

        public async Task<int> OutMay()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutMay", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutJune()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutJune", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        // Continue adding methods for the remaining months (July to December)

        public async Task<int> OutJuly()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutJuly", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutAugust()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutAugust", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        // Continue adding methods for the remaining months (September to December)

        public async Task<int> OutSeptember()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutSeptember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutOctober()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutOctober", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutNovember()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutNovember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> OutDecember()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("OutDecember", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> CountTimeOut()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountTimeOut", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<List<attendance>> CheckTimeOUT(string _studID, DateTime _timeOUT)
        {
            List<attendance> x = new List<attendance>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("CheckTimeOUT", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("_studID", _studID);
                    com.Parameters.AddWithValue("_timeOUT", _timeOUT);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        x.Add(new attendance
                        {
                            attendanceID = Convert.ToInt32(rdr["attendanceID"]),
                            studID = rdr["studID"].ToString(),
                            timeIN = rdr["timeIN"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeIN"]),
                            timeOUT = rdr["timeOUT"] is DBNull ? null :
                            (DateTime?)Convert.ToDateTime(rdr["timeOUT"]),

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

            return x;
        }

    }
}