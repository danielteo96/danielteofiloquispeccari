using Entity.result;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.HijosDAO
{
    public class HijosDAO
    {
        private string cadenaconexion = "Data Source=DANIEL-TEO-LENO\\SQLDANIEL;Initial " +
            "Catalog=DANIELQUISPE;Integrated Security=SSPI;";

        public List<Hijos> Obtenerhijos(int idhijo)
        {
            try
            {
                List<Hijos> listahijos = new List<Hijos>();
                Hijos dataencontrado = null;
                string sentencia = "SELECT idhijo, nombrecompleto, fechaNac  FROM tb_HIJOS where @idhijo = @idhijo";
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@idhijo", idhijo));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            while (resultado.Read())
                            {
                                dataencontrado = new Hijos
                                {
                                    idhijo = (int)resultado["idhijo"],
                                    nombrecompleto = (string)resultado["nombrecompleto"],
                                    fechaNac = (DateTime)resultado["fechaNac"]

                                };

                                listahijos.Add(dataencontrado);
                            }
                        }
                    }


                }
                return listahijos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Hijos obtener(int idhijo)
        {
            try
            {
                List<Hijos> listahijos = new List<Hijos>();
                Hijos dataencontrado = null;
                string sentencia = "SELECT idhijo, nombrecompleto, fechaNac  FROM tb_HIJOS where idhijo = @idhijo";
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@idhijo", idhijo));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            while (resultado.Read())
                            {
                                dataencontrado = new Hijos
                                {
                                    idhijo = (int)resultado["idhijo"],
                                    nombrecompleto = (string)resultado["nombrecompleto"],
                                    fechaNac = (DateTime)resultado["fechaNac"]

                                };

                                listahijos.Add(dataencontrado);
                            }
                        }
                    }


                }
                return listahijos.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Hijos Agregar(Hijos Hijosparam)
        {
            Hijos Hijoscreado = null;
            Hijos buscarhijo = obtener(Hijosparam.idhijo);
            if (buscarhijo == null)
            {


                string sentencia = "Insert into tb_HIJOS " +
                    "(idhijo,nombrecompleto,fechaNac,idpersonal)" +
                    "values(@idhijo,@nombrecompleto,@fechaNac,@idpersonal)";
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@idhijo", Hijosparam.idhijo));
                        comando.Parameters.Add(new SqlParameter("@nombrecompleto", Hijosparam.nombrecompleto));
                        comando.Parameters.Add(new SqlParameter("@fechaNac", Hijosparam.fechaNac));
                        comando.Parameters.Add(new SqlParameter("@idpersonal", 1));

                        comando.ExecuteNonQuery();
                    }
                }
                Hijoscreado = obtener(Hijosparam.idhijo);


                return Hijoscreado;
            }
            else
            {
                return Modificar(Hijosparam);
            }
        }
        public void eliminar(int idhijos)
        {
            string sentencia1 = "DELETE FROM tb_HIJOS where idhijo = @idhijo";
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia1, conexion))
                {

                    comando.Parameters.Add(new SqlParameter("@idhijo", idhijos));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public Hijos Modificar(Hijos hijosparam)
        {
            Hijos hijomodificado = null;
            Hijos buscarhijo = obtener(hijosparam.idhijo);
            if (buscarhijo != null)
            {

                //Hijos hijomodificado = null;
                string sentencia = "Update tb_HIJOS " +
                    "set nombrecompleto=@nombrecompleto," +
                    "fechaNac = @fechaNac " +
                    "where idhijo=@idhijo";

                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@idhijo", hijosparam.idhijo));
                        comando.Parameters.Add(new SqlParameter("@nombrecompleto", hijosparam.nombrecompleto));
                        comando.Parameters.Add(new SqlParameter("@fechaNac", hijosparam.fechaNac));
                        comando.ExecuteNonQuery();
                    }
                }
                hijomodificado = obtener(hijosparam.idhijo);
                return hijomodificado;
            }
            else
            {
                //hijomodificado = null;
                return hijomodificado;
            }
        }

    }
}
