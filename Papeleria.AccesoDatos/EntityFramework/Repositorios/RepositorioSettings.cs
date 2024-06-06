using Papeleria.LogicaNegocios.Entidades;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioSettings : IRepositorioSetting
    {
        private PapeleriaContext _context;
        public RepositorioSettings()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(Setting aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Setting> FindAll()
        {
            throw new NotImplementedException();
        }

        public Setting FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public double GetValueByName(string name)
        {
            return _context.Settings.Where(setting => setting.Name == name).FirstOrDefault().Value;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Setting aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
