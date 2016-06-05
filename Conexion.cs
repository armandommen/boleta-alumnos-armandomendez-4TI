using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Boleta
{
    class Conexion
    {
            string _connectionString = "Data Source=localhost;Initial Catalog=Boleta;Integrated Security=True";
            SqlConnection oCon;
            SqlCommand oCmd;
            SqlDataAdapter oAdapter;
            SqlDataReader oDr;
            DataTable oTable;

            public Conexion()
            {
                oCon = new SqlConnection(_connectionString);
            }
            public void Abrir()
            {
                oCon.Open();
            }
            public void Cerrar()
            {
                oCon.Close();
            }

            /// <summary>
            /// Método utilizado para insertar, modificar o eliminar datos de una base de datos
            /// </summary>
            /// <param name="StoreProcedure">Nombre del Procedimiento que se ejecutará en la base de datos</param>
            /// <param name="parametros">Listado de parametros</param>
            /// <returns>Número de registros insertados, alterados o eleminados de la base de datos</returns>
            public int EjecutaNonQuery(string StoreProcedure, List<SqlParameter> parametros)
            {
                int _correcto = 0;
                try
                {
                    oCon.Open();
                    oCmd = new SqlCommand();
                    oCmd.Connection = oCon;
                    oCmd.CommandText = StoreProcedure;
                    oCmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter param in parametros)
                    {
                        oCmd.Parameters.Add(param);
                    }
                    _correcto = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    oCon.Close();
                }
                return _correcto;
            }

            /// <summary>
            /// Método utilizado para obtener datos que serán visualizados dentro de un componente
            /// </summary>
            /// <param name="StoreProcedure">Nombre del procedimiento</param>
            /// <returns></returns>
            public DataTable ObtenerDatos(string StoreProcedure)
            {
                oTable = new DataTable();
                try
                {
                    oCon.Open();
                    oCmd = new SqlCommand();
                    oCmd.Connection = oCon;
                    oCmd.CommandText = StoreProcedure;
                    oCmd.CommandType = CommandType.StoredProcedure;

                    oAdapter = new SqlDataAdapter(oCmd);
                    oAdapter.Fill(oTable);

                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    oCon.Close();
                }

                return oTable;
            }
            public DataTable ObtenerDatos(string StoreProcedure, List<SqlParameter> Parametros)
            {
                oTable = new DataTable();
                try
                {
                    oCon.Open();
                    oCmd = new SqlCommand();
                    oCmd.Connection = oCon;
                    oCmd.CommandText = StoreProcedure;
                    oCmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter param in Parametros)
                    {
                        oCmd.Parameters.Add(param);
                    }

                    oAdapter = new SqlDataAdapter(oCmd);
                    oAdapter.Fill(oTable);

                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    oCon.Close();
                }

                return oTable;
            }

            /// <summary>
            /// Método utilizado para traer una columna de la base de datos
            /// </summary>
            /// <param name="StoreProcedure">Nombre del procedure</param>
            /// <returns></returns>
            public List<string> TraerDatos(string StoreProcedure)
            {
                List<string> Datos = new List<string>();
                try
                {
                    oCon.Open();
                    oCmd = new SqlCommand();
                    oCmd.Connection = oCon;
                    oCmd.CommandText = StoreProcedure;
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oDr = oCmd.ExecuteReader();
                    while (oDr.Read())
                    {
                        Datos.Add(oDr[0].ToString());
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    oCon.Close();
                }

                return Datos;
            }

            public string ObtenerDato(string StoreProcedure)
            {
                string Dato = "";
                try
                {
                    oCon.Open();
                    oCmd = new SqlCommand();
                    oCmd.Connection = oCon;
                    oCmd.CommandText = StoreProcedure;
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oDr = oCmd.ExecuteReader();

                    if (oDr.Read())
                    {
                        Dato = oDr[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    oCon.Close();
                }

                return Dato;
            }

            public string ObtenerDato(string StoreProcedure, List<SqlParameter> parametros)
            {
                string Dato = "";
                try
                {
                    oCon.Open();
                    oCmd = new SqlCommand();
                    oCmd.Connection = oCon;
                    oCmd.CommandText = StoreProcedure;
                    oCmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter param in parametros)
                    {
                        oCmd.Parameters.Add(param);
                    }

                    oDr = oCmd.ExecuteReader();

                    if (oDr.Read())
                    {
                        Dato = oDr[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    oCon.Close();
                }

                return Dato;
            }
        }
    }

