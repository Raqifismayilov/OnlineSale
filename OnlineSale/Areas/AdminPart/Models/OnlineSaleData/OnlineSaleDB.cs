using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using OnlineSale.Areas.AdminPart.Models.AdoConnect;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.UserSign;
using System.Text;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleData
{
    public class OnlineSaleDB
    {
        SqlConnection sqlConnection = null;
        SqlConnect connectionString = null;
        SqlCommand cmd = null;
        SqlDataAdapter dap = null;
        DataTable dt = null;
        public OnlineSaleDB() { }
        public OnlineSaleDB(string dbName)
        {
            connectionString = new SqlConnect(dbName);
        }
        public int insertMnCategory(AdminPanel adminPanel)
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("InsertMenuCategory", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminCategory", adminPanel.AdminCategory);
                cmd.Parameters.AddWithValue("@CategoryPath", adminPanel.CategoryPath);
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    return (int)cmd.Parameters["@Id"].Value;
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }
        public List<AdminPanel> getAdminPanel()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("GetAdminPanel", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<AdminPanel> adminPanelList = new List<AdminPanel>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool result;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["AdminUsert"].ToString(), out result))
                            datarowResult = result;
                        adminPanelList.Add(new AdminPanel
                        {
                            Id = (int)dr["Id"],
                            AdminCategory = dr["AdminCategory"].ToString(),
                            CategoryPath = dr["CategoryPath"].ToString(),
                            LogoPath = dr["logoPath"].ToString(),
                            AdminUsert = datarowResult,
                            RowsNum = (int)dr["RowsNum"]
                        });
                    }
                    return adminPanelList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public AdminPanel getAdminPanel(int Id)
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("GetAdmnPnlWhere", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id).SqlDbType = SqlDbType.Int;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    bool result;
                    bool? datarowResult = null;
                    if (bool.TryParse(dt.Rows[0][4].ToString(), out result))
                        datarowResult = result;
                    return new AdminPanel
                    {
                        Id = (int)dt.Rows[0][0],
                        AdminCategory = dt.Rows[0][1].ToString(),
                        CategoryPath = dt.Rows[0][2].ToString(),
                        LogoPath = dt.Rows[0][3].ToString(),
                        AdminUsert = datarowResult,
                        RowsNum = (int)dt.Rows[0][5]
                    };
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public bool deleteAdminPanel(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DelAdminPanel", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool insertAdminPanel(AdminPanel adminPanel)
        {
            if (adminPanel != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("AddAdminPanel", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminCategory", adminPanel.AdminCategory).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@CategoryPath", adminPanel.CategoryPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@logoPath", adminPanel.LogoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@AdminUsert", adminPanel.AdminUsert).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@RowsNum", adminPanel.RowsNum).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else return false;
        }
        public bool updateAdminPanel(AdminPanel adminPanel)
        {
            if (adminPanel != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateAdminPanel", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", adminPanel.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@AdminCategory", adminPanel.AdminCategory).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@CategoryPath", adminPanel.CategoryPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@LogoPath", adminPanel.LogoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@AdminUsert", adminPanel.AdminUsert).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@RowsNum", adminPanel.RowsNum).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool insertUser(UserMod user)
        {
            if (user != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertUser", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Username", user.Username).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Email", user.Email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@Password", user.PasswordHash).SqlDbType = SqlDbType.Binary;
                    cmd.Parameters.AddWithValue("@Salt", user.SaltHash).SqlDbType = SqlDbType.Binary;
                    cmd.Parameters.AddWithValue("@UserTypeId", user.UserTypeId).SqlDbType = SqlDbType.SmallInt;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0) return true;
                        return false;
                    }
                    catch (SqlException)
                    {
                        throw new Exception("Error data");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public UserMod GetFirstUser(string param)
        {
            string newParam = param.Trim();
            if (!(string.IsNullOrEmpty(newParam)) && newParam.Length != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    try
                    {
                        byte[] arrBinary = Convert.FromBase64String(newParam);
                        cmd = new SqlCommand("GetFirstUserH", sqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@Id", arrBinary).SqlDbType = SqlDbType.Binary;
                        dap = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        dt.Clear();
                        sqlConnection.Open();
                        dap.Fill(dt);
                        int rowsQuantity = dt.Rows.Count;
                        if (rowsQuantity != 0)
                        {
                            return (new UserMod
                            {
                                Id = (int)dt.Rows[0][0],
                                Firstname = dt.Rows[0][1].ToString(),
                                Lastname = dt.Rows[0][2].ToString(),
                                Username = dt.Rows[0][3].ToString(),
                                Email = dt.Rows[0][4].ToString(),
                                UserTypeId = (short)dt.Rows[0][5]
                            });
                        }
                        else
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        return null;// throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            if (dt.Rows.Count != 0)
                                dt.Clear();
                        }
                    }
                }
            }
            else
                throw new Exception("string.IsNullOrEmptry");
        }
        public List<UserMod> getUsers()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectUser", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sqlConnection.Open();
                    dt.Clear();
                    dap.Fill(dt);
                    List<UserMod> user = new List<UserMod>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        user.Add(new UserMod
                        {
                            Id = (int)dr["Id"],
                            Hid = (byte[])dr["hId"],
                            Firstname = dr["Firstname"].ToString(),
                            Lastname = dr["Lastname"].ToString(),
                            Username = dr["Username"].ToString(),
                            Email = dr["Email"].ToString(),
                            UserTypeId = (short)dr["UserTypeId"]
                        });
                    }
                    return user;
                }
                catch (Exception)
                {
                    return null;//  throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }

                }
            }
        }
        public List<UserMod> getUsers(int count)
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("UserPagination", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Count", count).SqlDbType = SqlDbType.Int;
                try
                {
                    dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sqlConnection.Open();
                    dt.Clear();
                    dap.Fill(dt);
                    List<UserMod> user = new List<UserMod>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        user.Add(new UserMod
                        {
                            Id = (int)dr["Id"],
                            Hid = (byte[])dr["hId"],
                            Firstname = dr["Firstname"].ToString(),
                            Lastname = dr["Lastname"].ToString(),
                            Username = dr["Username"].ToString(),
                            Email = dr["Email"].ToString(),
                            UserTypeId = (short)dr["UserTypeId"]
                        });
                    }
                    return user;
                }
                catch (Exception)
                {
                    return null;//  throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }

                }
            }
        }
        public bool updateUser(UserMod user)
        {
            if (user != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateUser", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", user.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Username", user.Username).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Email", user.Email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@Password", user.PasswordHash).SqlDbType = SqlDbType.Binary;
                    cmd.Parameters.AddWithValue("@Salt", user.SaltHash).SqlDbType = SqlDbType.Binary;
                    cmd.Parameters.AddWithValue("@UserTypeId", user.UserTypeId).SqlDbType = SqlDbType.SmallInt;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool deleteUser(string Id)
        {
            string newID = Id.Trim();
            if (!(string.IsNullOrEmpty(newID)) && newID.Length != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    try
                    {
                        byte[] arrBinary = Convert.FromBase64String(newID);
                        cmd = new SqlCommand("DeleteUser", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", arrBinary).SqlDbType = SqlDbType.Binary;
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool GetUserEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    try
                    {
                        cmd = new SqlCommand("GetUserEmail", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", email).SqlDbType = SqlDbType.VarChar;
                        dt = new DataTable();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public List<UserSignIn> UserLogin(UserSignIn usSgn)
        {
            if (usSgn != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    try
                    {
                        cmd = new SqlCommand("UserLogin", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", usSgn.Username).SqlDbType = SqlDbType.NVarChar;
                        dt = new DataTable();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        int rowCount = dt.Rows.Count;
                        if (rowCount != 0)
                        {
                            List<UserSignIn> usrList = new List<UserSignIn>(rowCount);
                            foreach (DataRow dr in dt.Rows)
                            {
                                usrList.Add(new UserSignIn()
                                {
                                    Username = dr["Username"].ToString(),
                                    HashPasword = (byte[])dr["Password"],
                                    HashSalt = (byte[])dr["Salt"]
                                });
                            }
                            return usrList;
                        }
                        return null;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else return null;
        }
        public bool findUser(string userName)
        {
            if (userName != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    try
                    {
                        cmd = new SqlCommand("UserLogin", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", userName).SqlDbType = SqlDbType.NVarChar;
                        dt = new DataTable();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        int rowCount = dt.Rows.Count;
                        if (rowCount != 0)
                            return true;
                        return false;

                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else return false;
        }
        public int InsertUserType(UserType userType)
        {
            if (userType != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertUserType", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserType", userType.TypeName);
                    cmd.Parameters.AddWithValue("@Id", userType.Id).Direction = ParameterDirection.Output;
                    try
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        return (int)cmd.Parameters["@Id"].Value;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return 0;
        }
        public UserType GetUserType(short Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("GetUserType", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        dap.Fill(dt);
                        sqlConnection.Open();
                        return new UserType
                        {
                            Id = (short)dt.Rows[0][0],
                            TypeName = dt.Rows[0][1].ToString()
                        };
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return null;
        }
        public List<UserType> getUserTypes()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("UserType", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sqlConnection.Open();
                    dt.Clear();
                    dap.Fill(dt);
                    List<UserType> userType = new List<UserType>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        userType.Add(new UserType
                        {
                            Id = (short)dr["Id"],
                            TypeName = dr["UserType"].ToString()
                        });
                    }
                    return userType;
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public bool deleteUserType(short Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteUserType", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    try
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool insertProduct(ProductCategory prdCategory)
        {
            if (prdCategory != null && string.IsNullOrEmpty(prdCategory.ProductName))
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertProductCategory", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", prdCategory.ProductName).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else return false;
        }
        public List<ProductCategory> getProductsCategory()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectFullCategory", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sqlConnection.Open();
                    dt.Clear();
                    dap.Fill(dt);
                    List<ProductCategory> category = new List<ProductCategory>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)

                    {
                        category.Add(new ProductCategory
                        {
                            Id = (int)dr["Id"],
                            ProductName = dr["ProductName"].ToString()
                        });
                    }
                    return category;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }

        public List<MadeIn> getMadeIn()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectMadeInFull", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sqlConnection.Open();
                    dt.Clear();
                    dap.Fill(dt);
                    int rowsCount = dt.Rows.Count;
                    if (rowsCount != 0)
                    {
                        List<MadeIn> madeIn = new List<MadeIn>(rowsCount);
                        foreach (DataRow dr in dt.Rows)
                        {
                            madeIn.Add(new MadeIn
                            {
                                Id = (short)dr["Id"],
                                Names = dr["Names"].ToString()
                            });
                        }
                        return madeIn;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;//   throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public ProductCategory getProdcut(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("SelectProdCatWhere", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    try
                    {
                        dap = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        dt.Clear();
                        dap.Fill(dt);
                        sqlConnection.Open();
                        return new ProductCategory
                        {
                            Id = (int)dt.Rows[0][0],
                            ProductName = dt.Rows[0][1].ToString()
                        };
                    }
                    catch (Exception)
                    {
                        return null;// throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return null;
        }
        public bool updateProduct(ProductCategory prdCategory)
        {
            if (prdCategory != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateProdcutCategory", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", prdCategory.Id);
                    cmd.Parameters.AddWithValue("@ProductName", prdCategory.ProductName);
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool deleteProduct(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteProductCategory", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public bool deleteSubProduct(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteSubPrdCat", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public ProductSubCategory getSubProduct(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("SelectSubPrdCatWhere", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id).SqlDbType= SqlDbType.Int;
                    try
                    {
                        dap = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sqlConnection.Open();
                        dt.Clear();
                        dap.Fill(dt);
                        return new ProductSubCategory
                        {
                            Id = (int)dt.Rows[0][0],
                            SubPrdName = dt.Rows[0][1].ToString(),
                            ProductCategoryId = (int)dt.Rows[0][2],
                            MadeInId = (short)dt.Rows[0][3]
                        };
                    }
                    catch (Exception)
                    {
                        return null;// throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return null;
        }
        public List<ProductSubCategory> getSubProducts()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectSubPrdCatFull", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dt = new DataTable();
                    dt.Clear();
                    dap.Fill(dt);
                    List<ProductSubCategory> prdSubCategory = new List<ProductSubCategory>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        prdSubCategory.Add(
                            new ProductSubCategory
                            {
                                Id = (int)dr["Id"],
                                SubPrdName = dr["SubPrdName"].ToString(),
                                ProductCategoryId = (int)dr["ProductCategoryId"],
                                MadeInId = (short)dr["MadeInId"]
                            }
                        );
                    }

                    return prdSubCategory;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public bool insertSubProduct(ProductSubCategory subProduct)
        {
            if (subProduct != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertSubPrdCat", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubPrdName", subProduct.SubPrdName).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@ProductCategoryId", (int)subProduct.ProductCategoryId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@MadeInId", (short)subProduct.MadeInId).SqlDbType = SqlDbType.SmallInt;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                          throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool updateSubProduct(ProductSubCategory subProduct)
        {
            if (subProduct != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateSubPrdCat", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", subProduct.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@SubPrdName", subProduct.SubPrdName).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@ProductCategoryId", (int)subProduct.ProductCategoryId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@MadeInId", (short)subProduct.MadeInId).SqlDbType = SqlDbType.SmallInt;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public List<Stock> getStockList()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("FullStockJoin", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<Stock> stckList = new List<Stock>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        int result;
                        int? dataRwSubEndId = null;
                        if (int.TryParse(dr["SubEndirimId"].ToString(), out result))
                            dataRwSubEndId = result;

                        bool prdCondition;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                            datarowResult = prdCondition;

                        stckList.Add(new Stock
                        {
                            Id = (int)dr["Id"],
                            ProductId = (int)dr["ProductCategoryId"],
                            SubProductCategoryId = (int)dr["SubProductCategoryId"],
                            ProductName = dr["ProductName"].ToString(),
                            SubColorId = (int)dr["SubColorId"],
                            MainPhotoPath = dr["MainPhotoPath"].ToString(),
                            Price = Convert.ToDouble(dr["Price"]),
                            SubValutaId = (int)dr["SubValutaId"],
                            Quantity = (int)dr["Quantity"],
                            Endirim = Convert.ToDouble(dr["Endirim"]),
                            SubEndirimId = dataRwSubEndId,
                            RowsNumber = (int)dr["RowsNumber"],
                            ProductCondition = datarowResult,
                            ProductCode = dr["ProductCode"].ToString()
                        });
                    }
                    return stckList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<StockUser> getStockStrList()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectFullStock1", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<StockUser> stckList = new List<StockUser>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool prdCondition;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                            datarowResult = prdCondition;

                        stckList.Add(new StockUser
                        {
                            Id = (int)dr["Id"],
                            ProductCategory = dr["ProductCategory"].ToString(),
                            SubPrdName = dr["SubPrdName"].ToString(),
                            ProductName = dr["ProductName"].ToString(),
                            ColorsCode = dr["ColorsCode"].ToString(),
                            MainPhotoPath = dr["MainPhotoPath"].ToString(),
                            Price = Convert.ToDouble(dr["Price"]),
                            ValutaType = dr["ValutaType"].ToString(),
                            Quantity = (int)dr["Quantity"],
                            Endirim = Convert.ToDouble(dr["Endirim"]),
                            EndirimType = dr["EndirimType"].ToString(),
                            RowsNumber = (int)dr["RowsNumber"],
                            ProductCondition = datarowResult,
                            ProductCode = dr["ProductCode"].ToString()

                        });
                    }
                    return stckList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<StockUser> weekDiscount()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("WeekDiscount", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<StockUser> stckList = new List<StockUser>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool prdCondition;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                            datarowResult = prdCondition;

                        stckList.Add(new StockUser
                        {
                            Id = (int)dr["Id"],
                            ProductCategory = dr["ProductCategory"].ToString(),
                            SubPrdName = dr["SubPrdName"].ToString(),
                            ProductName = dr["ProductName"].ToString(),
                            ColorsCode = dr["ColorsCode"].ToString(),
                            MainPhotoPath = dr["MainPhotoPath"].ToString(),
                            Price = Convert.ToDouble(dr["Price"]),
                            ValutaType = dr["ValutaType"].ToString(),
                            Quantity = (int)dr["Quantity"],
                            Endirim = Convert.ToDouble(dr["Endirim"]),
                            EndirimType = dr["EndirimType"].ToString(),
                            RowsNumber = (int)dr["RowsNumber"],
                            ProductCondition = datarowResult,
                            ProductCode = dr["ProductCode"].ToString()
                        });
                    }
                    return stckList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<StockUser> getStockStrEndirimTop()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("StockEndirimProduct10", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<StockUser> stckList = new List<StockUser>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool prdCondition;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                            datarowResult = prdCondition;

                        stckList.Add(new StockUser
                        {
                            Id = (int)dr["Id"],
                            ProductCategory = dr["ProductCategory"].ToString(),
                            SubPrdName = dr["SubPrdName"].ToString(),
                            ProductName = dr["ProductName"].ToString(),
                            ColorsCode = dr["ColorsCode"].ToString(),
                            MainPhotoPath = dr["MainPhotoPath"].ToString(),
                            Price = Convert.ToDouble(dr["Price"]),
                            ValutaType = dr["ValutaType"].ToString(),
                            Quantity = (int)dr["Quantity"],
                            Endirim = Convert.ToDouble(dr["Endirim"]),
                            EndirimType = dr["EndirimType"].ToString(),
                            RowsNumber = (int)dr["RowsNumber"],
                            ProductCondition = datarowResult,
                            ProductCode = dr["ProductCode"].ToString()
                        });
                    }
                    return stckList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<StockUser> getStockStrNewTop()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("StockNewProduct10", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<StockUser> stckList = new List<StockUser>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool prdCondition;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                            datarowResult = prdCondition;

                        stckList.Add(new StockUser
                        {
                            Id = (int)dr["Id"],
                            ProductCategory = dr["ProductCategory"].ToString(),
                            SubPrdName = dr["SubPrdName"].ToString(),
                            ProductName = dr["ProductName"].ToString(),
                            ColorsCode = dr["ColorsCode"].ToString(),
                            MainPhotoPath = dr["MainPhotoPath"].ToString(),
                            Price = Convert.ToDouble(dr["Price"]),
                            ValutaType = dr["ValutaType"].ToString(),
                            Quantity = (int)dr["Quantity"],
                            Endirim = Convert.ToDouble(dr["Endirim"]),
                            EndirimType = dr["EndirimType"].ToString(),
                            RowsNumber = (int)dr["RowsNumber"],
                            ProductCondition = datarowResult,
                            ProductCode = dr["ProductCode"].ToString()
                        });
                    }
                    return stckList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<StockUser> getStockWherePrd(int id)
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("StockWhereProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id).SqlDbType = SqlDbType.Int;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<StockUser> stckList = new List<StockUser>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool prdCondition;
                        bool? datarowResult = null;
                        if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                            datarowResult = prdCondition;

                        stckList.Add(new StockUser
                        {
                            Id = (int)dr["Id"],
                            ProductCategory = dr["ProductCategory"].ToString(),
                            SubPrdName = dr["SubPrdName"].ToString(),
                            ProductName = dr["ProductName"].ToString(),
                            ColorsCode = dr["ColorsCode"].ToString(),
                            MainPhotoPath = dr["MainPhotoPath"].ToString(),
                            Price = Convert.ToDouble(dr["Price"]),
                            ValutaType = dr["ValutaType"].ToString(),
                            Quantity = (int)dr["Quantity"],
                            Endirim = Convert.ToDouble(dr["Endirim"]),
                            EndirimType = dr["EndirimType"].ToString(),
                            RowsNumber = (int)dr["RowsNumber"],
                            ProductCondition =  datarowResult,
                            ProductCode = dr["ProductCode"].ToString()
                        });
                    }
                    return stckList;
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<Stock> searchInStock(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("SearchInAnbar", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", productName).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        List<Stock> stckList = new List<Stock>(dt.Rows.Count);
                        foreach (DataRow dr in dt.Rows)
                        {
                            bool prdCondition;
                            bool? datarowResult = null;
                            if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                                datarowResult = prdCondition;

                            stckList.Add(new Stock
                            {
                                Id = (int)dr["Id"],
                                ProductName = dr["ProductName"].ToString(),
                                SubProductCategoryId = (int)dr["SubProductCategoryId"],
                                SubColorId = (int)dr["SubColorId"],
                                MainPhotoPath = dr["MainPhotoPath"].ToString(),
                                Price = Convert.ToDouble(dr["Price"]),
                                SubValutaId = (int)dr["SubValutaId"],
                                Quantity = (int)dr["Quantity"],
                                Endirim = Convert.ToDouble(dr["Endirim"]),
                                SubEndirimId = (int)dr["SubEndirimId"],
                                RowsNumber = (int)dr["RowsNumber"],
                                ProductCondition = datarowResult,
                                ProductCode = dr["ProductCode"].ToString()
                            });
                        }
                        return stckList;
                    }
                    catch (Exception)
                    {
                        return null;//  throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return new List<Stock>();
        }
        public bool insertStock(Stock stock)
        {
            if (stock != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertStock", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", stock.ProductName).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@SubProductCategoryId", stock.SubProductCategoryId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@SubColorId", stock.SubColorId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@MainPhotoPath", stock.MainPhotoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Price", stock.Price).SqlDbType = SqlDbType.Float;
                    cmd.Parameters.AddWithValue("@SubValutaId", stock.SubValutaId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Quantity", stock.Quantity).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Endirim", stock.Endirim).SqlDbType = SqlDbType.Float;
                    if (stock.SubEndirimId != null)
                        cmd.Parameters.AddWithValue("@SubEndirimId", stock.SubEndirimId).SqlDbType = SqlDbType.Int;
                    else
                        cmd.Parameters.AddWithValue("@SubEndirimId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@RowsNumber", stock.RowsNumber).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@ProductCondition", stock.ProductCondition).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@ProductCode", stock.ProductCode).SqlDbType = SqlDbType.VarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;

        }
        public Stock getStock(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("SelectStockWhere", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        int result;
                        int? SubEndrimIdResult = null;
                        if (int.TryParse(dt.Rows[0][9].ToString(), out result))
                            SubEndrimIdResult = result;
                        return new Stock
                        {
                            Id = Convert.ToInt32(dt.Rows[0][0]),
                            ProductName = dt.Rows[0][1].ToString(),
                            SubProductCategoryId = Convert.ToInt32(dt.Rows[0][2]),
                            SubColorId = Convert.ToInt32(dt.Rows[0][3]),
                            MainPhotoPath = dt.Rows[0][4].ToString(),
                            Price = Convert.ToDouble(dt.Rows[0][5]),
                            SubValutaId = Convert.ToInt32(dt.Rows[0][6]),
                            Quantity = Convert.ToInt32(dt.Rows[0][7]),
                            Endirim = Convert.ToDouble(dt.Rows[0][8]),
                            SubEndirimId = SubEndrimIdResult,
                            RowsNumber = Convert.ToInt32(dt.Rows[0][10]),
                            ProductCondition = Convert.ToBoolean(dt.Rows[0][11]),
                            ProductCode = dt.Rows[0][12].ToString()
                        };
                    }
                    catch (Exception)
                    {
                        return null;// throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return null;
        }
        public bool updateStock(Stock stock)
        {
            if (stock != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    stock.SubEndirimId = 1;
                    cmd = new SqlCommand("UpdateStock", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", stock.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@ProductName", stock.ProductName).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@SubProductCategoryId", stock.SubProductCategoryId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@SubColorId", stock.SubColorId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@MainPhotoPath", stock.MainPhotoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Price", stock.Price).SqlDbType = SqlDbType.Float;
                    cmd.Parameters.AddWithValue("SubValutaId", stock.SubValutaId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Quantity", stock.Quantity).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Endirim", stock.Endirim).SqlDbType = SqlDbType.Float;
                    cmd.Parameters.AddWithValue("@SubEndirimId", stock.SubEndirimId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@RowsNumber", stock.RowsNumber).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@ProductCondition", stock.ProductCondition).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@ProductCode", stock.ProductCode).SqlDbType = SqlDbType.VarChar;
                    try
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else return false;
        }
        public bool deleteStock(int Id)
        {
            if (Id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteStock", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public List<StockUser> searchProduct(SearchInCategory searchIn)
        {
            if (searchIn != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    string sw = "";
                    if (searchIn.ProductId != 0)
                    {
                        sw = " and ProductCategory_Tb.Id=@Product";
                    }
                    if (searchIn.SubProductId != 0)
                    {
                        sw = " and SubProductCategory_Tb.Id=@SubProduct";
                    }
                    if (searchIn.ProductCondition != null)
                    {
                        sw = " and ProductCondition=@ProductCondition";
                    }
                    cmd = new SqlCommand(@" SELECT Stock_Tb.Id as [Id],Stock_Tb.ProductName,SubPrdName,
 ProductCategory_Tb.ProductName as ProductCategory,ColorsCode,MainPhotoPath,Price,
 ValutaType,Quantity,Endirim,EndirimType,RowsNumber,ProductCondition,ProductCode
 FROM Stock_Tb left join SubProductCategory_Tb 
 left join ProductCategory_Tb
 on SubProductCategory_Tb.ProductCategoryId=ProductCategory_Tb.Id
 on Stock_Tb.SubProductCategoryId=SubProductCategory_Tb.Id left join SubColors_Tb
 on Stock_Tb.SubColorId=SubColors_Tb.Id
 left join SubValuta_Tb on Stock_Tb.SubValutaId=SubValuta_Tb.Id
 left join SubEndrim_Tb on Stock_Tb.SubEndirimId=SubEndrim_Tb.Id
  where Stock_Tb.ProductName LIKE '%'+@PrdName+'%' " + sw, sqlConnection);
                    if (searchIn.ProductId != 0)
                        cmd.Parameters.AddWithValue("@Product", searchIn.ProductId).SqlDbType = SqlDbType.Int;
                    if (searchIn.SubProductId != 0)
                        cmd.Parameters.AddWithValue("@SubProduct", searchIn.SubProductId).SqlDbType = SqlDbType.Int;
                    if (searchIn.ProductName == null)
                        searchIn.ProductName = "";
                    cmd.Parameters.AddWithValue("@PrdName", searchIn.ProductName).SqlDbType = SqlDbType.NVarChar;

                    if (searchIn.ProductCondition != null)
                        cmd.Parameters.AddWithValue("@ProductCondition", searchIn.ProductCondition).SqlDbType = SqlDbType.Bit;

                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        int rowCount = dt.Rows.Count;
                        if (rowCount != 0)
                        {
                            List<StockUser> stckList = new List<StockUser>(rowCount);
                            foreach (DataRow dr in dt.Rows)
                            {
                                bool prdCondition;
                                bool? datarowResult = null;
                                if (bool.TryParse(dr["ProductCondition"].ToString(), out prdCondition))
                                    datarowResult = prdCondition;

                                stckList.Add(new StockUser
                                {
                                    Id = (int)dr["Id"],
                                    ProductCategory = dr["ProductCategory"].ToString(),
                                    SubPrdName = dr["SubPrdName"].ToString(),
                                    ProductName = dr["ProductName"].ToString(),
                                    ColorsCode = dr["ColorsCode"].ToString(),
                                    MainPhotoPath = dr["MainPhotoPath"].ToString(),
                                    Price = Convert.ToDouble(dr["Price"]),
                                    ValutaType = dr["ValutaType"].ToString(),
                                    Quantity = (int)dr["Quantity"],
                                    Endirim = Convert.ToDouble(dr["Endirim"]),
                                    EndirimType = dr["EndirimType"].ToString(),
                                    RowsNumber = (int)dr["RowsNumber"],
                                    ProductCondition = datarowResult,
                                    ProductCode = dr["ProductCode"].ToString()
                                });
                            }
                            return stckList;
                        }
                        else
                            return new List<StockUser>();
                    }
                    catch (Exception)
                    {
                         throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else return null;
        }
        public bool insertSlide(SlideMod slide)
        {
            if (slide != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertSlide", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StockId", slide.StockId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@PhotoPath", slide.PhotoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@RowsNumber", slide.RowsNumber).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public SlideMod getSlide(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("SelectSlide", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            return new SlideMod
                            {
                                Id = (int)dt.Rows[0][0],
                                StockId = (int)dt.Rows[0][1],
                                PhotoPath = dt.Rows[0][2].ToString(),
                                RowsNumber = (int)dt.Rows[0][3]
                            };
                        }
                        else
                            return null;

                    }
                    catch (Exception)
                    {
                        return null;//  throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return null;
        }
        public SlideMod getSlideStock(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    //SelecSlideStock
                    cmd = new SqlCommand("StockSlideSelect", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            return new SlideMod
                            {
                                Id = (int)dt.Rows[0][0],
                                StockId = (int)dt.Rows[0][1],
                                PhotoPath = "#",
                                RowsNumber = 1
                                //PhotoPath = dt.Rows[0][2].ToString(),
                                //RowsNumber = (int)dt.Rows[0][3]
                            };
                        }
                        else
                            return null;

                    }
                    catch (Exception)
                    {
                        return null;// throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return null;
        }
        public List<SlideMod> getSlideList()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("FullSlide", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    sqlConnection.Close();
                    if (dt.Rows.Count != 0)
                    {
                        List<SlideMod> slideList = new List<SlideMod>(dt.Rows.Count);
                        foreach (DataRow dr in dt.Rows)
                        {
                            slideList.Add(new SlideMod
                            {
                                Id = (int)dr["Id"],
                                StockId = (int)dr["StockId"],
                                PhotoPath = dr["PhotoPath"].ToString(),
                                RowsNumber = (int)dr["RowsNumber"],
                                SubProductId = (int)dr["SubProductId"],
                                ProductId = (int)dr["ProductId"]
                            });
                        }
                        return slideList;
                    }
                    return new List<SlideMod>();
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<SlideMod> getSlideList(int stockId)
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("FullSlideWhere", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StockId", stockId).SqlDbType = SqlDbType.Int;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    sqlConnection.Close();
                    if (dt.Rows.Count != 0)
                    {
                        List<SlideMod> slideList = new List<SlideMod>(dt.Rows.Count);
                        foreach (DataRow dr in dt.Rows)
                        {
                            slideList.Add(new SlideMod
                            {
                                Id = (int)dr["Id"],
                                StockId = (int)dr["StockId"],
                                ProductName = dr["ProductName"].ToString(),
                                PhotoPath = dr["PhotoPath"].ToString(),
                                RowsNumber = (int)dr["RowsNumber"],
                                SubProductId = (int)dr["SubProductId"],
                                ProductId = (int)dr["ProductId"]
                            });
                        }
                        return slideList;
                    }
                    return new List<SlideMod>();
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public bool updateSlide(SlideMod slide)
        {
            if (slide != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateSlide", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", slide.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@StockId", slide.StockId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@PhotoPath", slide.PhotoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@RowsNumber", slide.RowsNumber).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool deleteSlide(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteSlide", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            return false;
        }
        public List<SubColor> getColors()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectSubClrFull", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<SubColor> colorList = new List<SubColor>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        colorList.Add(new SubColor
                        {
                            Id = (int)dr["Id"],
                            ColorsCode = dr["ColorsCode"].ToString()
                        });
                    }
                    return colorList;
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<SubEndrim> getEndrims()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectSubEndr", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<SubEndrim> endrimList = new List<SubEndrim>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        endrimList.Add(new SubEndrim
                        {
                            Id = (int)dr["Id"],
                            EndrimType = dr["EndirimType"].ToString()
                        });
                    }
                    return endrimList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<SubValuta> getValutas()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectSubVltFull", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<SubValuta> valutaList = new List<SubValuta>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        valutaList.Add(new SubValuta
                        {
                            Id = (int)dr["Id"],
                            ValutaType = dr["ValutaType"].ToString()
                        });
                    }
                    return valutaList;
                }
                catch (Exception)
                {
                    return null;//  throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<FooterMod> getFooters()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("SelectFooter", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<FooterMod> footerList = new List<FooterMod>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        footerList.Add(
                            new FooterMod
                            {
                                Id = (short)dr["Id"],
                                Copyright = dr["Copyright"].ToString(),
                                Header = dr["Header"].ToString(),
                                Body = dr["Body"].ToString(),
                                Footer = dr["Footer"].ToString()
                            });
                    }
                    return footerList;
                }
                catch (Exception)
                {
                    return null;//  throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public bool insertProductDetail(ProductDetail prdDetail)
        {
            if (prdDetail != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("AddProductDetail", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StockId", prdDetail.StockId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Name", prdDetail.Name).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Value", prdDetail.Values).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool updateProductDetail(ProductDetail prdDetail)
        {
            if (prdDetail != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateProductDetail", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", prdDetail.ProductId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@StockId", prdDetail.StockId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@Name", prdDetail.Name).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Value", prdDetail.Values).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public List<ProductDetail> getProductDetail(int stockId)
        {
            if (stockId != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("ProductDetailJoinStockId", sqlConnection);
                    cmd.Parameters.AddWithValue("@StockId", stockId).SqlDbType = SqlDbType.Int;
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            List<ProductDetail> productDetail = new List<ProductDetail>(dt.Rows.Count);
                            foreach (DataRow dr in dt.Rows)
                            {
                                productDetail.Add(
                                    new ProductDetail
                                    {
                                        ProductId = (int)dr["Id"],
                                        StockId = (int)dr["StockId"],
                                        ProductCategory = dr["ProductName"].ToString(),
                                        ProductSubCategory = dr["SubPrdName"].ToString(),
                                        Name = dr["Name"].ToString(),
                                        Values = dr["Value"].ToString()
                                    }
                                );
                            }
                            return productDetail;
                        }
                        else
                            return new List<ProductDetail>();
                    }
                    catch (Exception)
                    {
                        return null;// throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else return null;

        }
        public ProductDetail getSubPrdDetail(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("ProductDetailWhere", sqlConnection);
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            return new ProductDetail()
                            {
                                ProductId = (int)dt.Rows[0][0],
                                StockId = (int)dt.Rows[0][1],
                                Name = dt.Rows[0][2].ToString(),
                                Values = dt.Rows[0][3].ToString()
                            };
                        }
                        else
                            return null;
                    }
                    catch (Exception)
                    {
                        return null;//  throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return null;
        }
        public bool deleteProductDetail(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    try
                    {
                        cmd = new SqlCommand("DeleteProductDetail", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool insertMainSlide(MainSlide mainSlide)
        {
            if (mainSlide != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertMainSlide", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SlideName", mainSlide.SlideName).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@PhotoPath", mainSlide.PhotoPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@RowNumber", mainSlide.RowNumber).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public List<MainSlide> getMainSlide(int count)
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("GetMainSlideTopCount", sqlConnection);
                cmd.Parameters.AddWithValue("@Count", count).SqlDbType = SqlDbType.Int;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<MainSlide> slideList = new List<MainSlide>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        slideList.Add(new MainSlide
                        {
                            Id = (int)dr["Id"],
                            SlideName = dr["SlideName"].ToString(),
                            PhotoPath = dr["PhotoPath"].ToString(),
                            RowNumber = (int)dr["RowNumber"],
                        });
                    }
                    return slideList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public List<MainSlide> getMainSlide()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("GetMainSlideTop5", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<MainSlide> slideList = new List<MainSlide>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        slideList.Add(new MainSlide
                        {
                            Id = (int)dr["Id"],
                            SlideName = dr["SlideName"].ToString(),
                            PhotoPath = dr["PhotoPath"].ToString(),
                            RowNumber = (int)dr["RowNumber"],
                        });
                    }
                    return slideList;
                }
                catch (Exception)
                {
                   throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public bool updateMainSlide(int id)
        {
            if (id != 0)
            {
                return true;
            }
            else
                return false;
        }
        public List<AboutMod> getAboutList()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("GetAbout", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        List<AboutMod> about = new List<AboutMod>(dt.Rows.Count);
                        foreach (DataRow dr in dt.Rows)
                        {
                            about.Add(new AboutMod
                            {

                                Id = (short)dr["Id"],
                                Header = dr["Header"].ToString(),
                                Body = dr["Body"].ToString(),
                                Footer = dr["Footer"].ToString()
                            });
                        }
                        return about;
                    }
                    else
                        return new List<AboutMod>();
                }
                catch (Exception)
                {
                    return null;//  throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();
                }
            }
        }
        public AboutMod GetAbout(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("GetAboutWhere", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)

                            return new AboutMod
                            {
                                Id = (short)dt.Rows[0][0],
                                Header = dt.Rows[0][1].ToString(),
                                Body = dt.Rows[0][2].ToString(),
                                Footer = dt.Rows[0][3].ToString()
                            };
                        return new AboutMod();
                    }
                    catch (Exception)
                    {
                        return null;//  throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return new AboutMod();
        }
        public bool insertAbout(AboutMod about)
        {
            if (about != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertAbout", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Header", about.Header).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Body", about.Body).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Footer", about.Footer).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            return false;
        }
        public bool updateAbout(AboutMod about)
        {
            if (about != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateAbout", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", about.Id);
                    cmd.Parameters.AddWithValue("@Header", about.Header).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Body", about.Body).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Footer", about.Footer).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool deleteAbout(int id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteAbout", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;

                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public bool insertContact(ContactMod contact)
        {
            if (contact != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("InsertContact", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Number", contact.Number).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@MobNumber", contact.MobNumber).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Email", contact.Email).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@MapPath", contact.MapPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@OurAddress", contact.OurAddress).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else
                return false;
        }
        public List<ContactMod> getContactList()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                cmd = new SqlCommand("GetContact", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    dt = new DataTable();
                    dt.Clear();
                    dap = new SqlDataAdapter(cmd);
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<ContactMod> contactList = new List<ContactMod>(dt.Rows.Count);
                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            contactList.Add(
                                new ContactMod
                                {
                                    Id = (short)dr["Id"],
                                    Number = dr["Number"].ToString(),
                                    MobNumber = dr["MobNumber"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    MapPath = dr["MapPath"].ToString(),
                                    OurAddress = dr["OurAddress"].ToString()
                                });
                        }
                        return contactList;
                    }
                    else
                        return contactList;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        dt.Clear();
                    }
                }
            }
        }
        public ContactMod getContact(short id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("GetContactWhere", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.Int;
                    try
                    {
                        dt = new DataTable();
                        dt.Clear();
                        dap = new SqlDataAdapter(cmd);
                        sqlConnection.Open();
                        dap.Fill(dt);
                        if (dt.Rows.Count != 0)
                            return new ContactMod
                            {
                                Id = (short)dt.Rows[0][0],
                                Number = dt.Rows[0][1].ToString(),
                                MobNumber = dt.Rows[0][2].ToString(),
                                Email = dt.Rows[0][3].ToString(),
                                MapPath = dt.Rows[0][4].ToString(),
                                OurAddress = dt.Rows[0][5].ToString()
                            };
                        return new ContactMod();
                    }
                    catch (Exception)
                    {
                        return null;//  throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            dt.Clear();
                        }
                    }
                }
            }
            else
                return new ContactMod();
        }
        public bool updateContact(ContactMod contact)
        {
            if (contact != null)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("UpdateContact", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", contact.Id).SqlDbType = SqlDbType.SmallInt;
                    cmd.Parameters.AddWithValue("@Number", contact.Number).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@MobNumber", contact.MobNumber).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@Email", contact.Email).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@MapPath", contact.MapPath).SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.AddWithValue("@OurAddress", contact.OurAddress).SqlDbType = SqlDbType.NVarChar;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            else return false;
        }
        public bool deleteContact(short id)
        {
            if (id != 0)
            {
                using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
                {
                    cmd = new SqlCommand("DeleteContact", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id).SqlDbType = SqlDbType.SmallInt;
                    try
                    {
                        sqlConnection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != 0)
                            return true;
                        return false;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error");
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }
            }
            return false;
        }
        public List<SocialMediaMod> getSocialMedia()
        {
            using (sqlConnection = new SqlConnection(connectionString.ConnectStr))
            {
                try
                {
                    cmd = new SqlCommand("GetSocialMedia", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    dt.Clear();
                    sqlConnection.Open();
                    dap.Fill(dt);
                    List<SocialMediaMod> socialMedia = new List<SocialMediaMod>(dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        socialMedia.Add(new SocialMediaMod
                        {
                            Id = (short)dr["Id"],
                            SocName = dr["SocName"].ToString(),
                            SocPath = dr["SocPath"].ToString()
                        });
                    }
                    return socialMedia;
                }
                catch (Exception)
                {
                    return null;// throw new Exception("Error");
                }
                finally
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();
                }
            }

        }
    }
}
