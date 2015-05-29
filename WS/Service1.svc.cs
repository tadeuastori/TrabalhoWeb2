using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.ModelBinding;
using TrabalhoWeb2.Models;
using WS.Model;

namespace WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool verificaLogin(string usuario, string senha)
        {
            bool result = false;

            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    if (dac.Usuario.Where(x => x.Login == usuario && x.Senha == senha).ToList().Count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool adicionaUsuario(Usuario usuario)
        {
            bool result = false;

            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    if (usuario != null)
                    {
                        dac.Usuario.Add(usuario);
                        dac.SaveChanges();

                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool adicionaAgenda(Agenda agenda)
        {
            bool result = false;

            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    if (agenda != null)
                    {
                        dac.Agenda.Add(agenda);
                        dac.SaveChanges();

                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool adicionaParticipante(Participantes participante)
        {
            bool result = false;

            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    if (participante != null)
                    {
                        dac.Participantes.Add(participante);
                        dac.SaveChanges();

                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public List<Agenda> lstCompromissos(int IdUsuario, int qtd = 0)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    if(qtd > 0)
                    {
                        return dac.Agenda.Where(x => x.UsuarioId == IdUsuario && x.DataCompromisso >= DateTime.Now).Take(qtd).OrderBy(o => o.DataCompromisso).ToList();
                    }
                    else
                    {
                        return dac.Agenda.Where(x => x.UsuarioId == IdUsuario && x.DataCompromisso >= DateTime.Now).OrderBy(o => o.DataCompromisso).ToList();
                    }
                    
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Usuario> lstUsuario(int idUsuario)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    return dac.Usuario.Where(x => x.UsuarioId != idUsuario).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Participantes> lstParticipantesCompromisso(int idAgenda)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    return dac.Participantes.Where(x => x.AgendaId == idAgenda).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Agenda retornaCompromisso(int idAgenda)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    return dac.Agenda.Where(x => x.AgendaId == idAgenda).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario retornaUsuarioPorID(int idUsuario)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    return dac.Usuario.Where(x => x.UsuarioId == idUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario retornaUsuarioPorLOGIN(string login)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    Usuario user = dac.Usuario.Where(x => x.Login == login).FirstOrDefault();


                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Usuario> lstUsuarioParticipantes(List<Participantes> lstPart)
        {
            try
            {
                using (DataAccessController dac = new DataAccessController())
                {
                    List<Usuario> user = dac.Usuario.ToList();

                    foreach (Participantes part in lstPart)
                    {
                        foreach (Usuario usua in user)
                        {
                            if (part.UsuarioID != usua.UsuarioId)
                            {
                                user.Remove(usua);
                            }
                        }
                    }

                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
