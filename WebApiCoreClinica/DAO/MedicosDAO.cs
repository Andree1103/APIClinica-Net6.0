using System.Data.SqlClient;
using WebApiCoreClinica.Models;

namespace WebApiCoreClinica.DAO
{
    public class MedicosDAO
    {
        private readonly string cad_conexion;

        public MedicosDAO(IConfiguration config)
        {
            cad_conexion = config.GetConnectionString("cn1");
        }

        public List<Medicos> ListarMedicos()
        {
            var list = new List<Medicos>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conexion, "PA_MEDICOS");
            while (dr.Read())
            {
                list.Add(new Medicos()
                {
                    codmed = dr.GetString(0),
                    nommed = dr.GetString(1),
                    anio_colegio = dr.GetInt32(2),
                    codesp = dr.GetString(3),
                    coddis = dr.GetString(4),
                    eliminado = dr.GetString(5),
                });
            }
            dr.Close();
            return list;
        }


        public string GrabarMedico(Medicos obj)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion, "PA_INSERTAR_MEDICO",
                    obj.codmed, obj.nommed, obj.anio_colegio, obj.codesp, obj.coddis);
                mensaje = $"El Medico {obj.nommed} fue regsitrado correctamente";
            }
            catch (Exception ex) 
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string ActualizarMedico(Medicos obj)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion, "PA_ACTUALIZAR_MEDICO",
                    obj.codmed, obj.nommed, obj.anio_colegio, obj.codesp, obj.coddis);
                mensaje = $"El Medico de codigo: {obj.codmed} fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string EliminarMedico(string codmed)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion, "PA_ELIMINAR_MEDICO_LOG",
                    codmed);
                mensaje = $"El Medico de codigo: {codmed} fue eliminado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        //Por Comodidad colocaremos los listados para utilizarlos en un dropdownlist si no cada uno de ellos deberita tener su dao


        public List<Especialidad> ListarEspecialidad()
        {
            var lista = new List<Especialidad>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conexion, "PA_ESPECIALIDAD");
            while (dr.Read())
            {
                lista.Add(new Especialidad()
                {
                    codesp = dr.GetString(0),
                    nomesp = dr.GetString(1),
                    costo = dr.GetInt32(2),
                    eliminado = dr.GetString(3),
                });
            }
            dr.Close();
            return lista;
        }


    }
}
