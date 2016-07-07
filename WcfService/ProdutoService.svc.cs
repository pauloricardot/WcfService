using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Text;
using System.Xml;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProdutoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProdutoService.svc or ProdutoService.svc.cs at the Solution Explorer and start debugging.
    public class ProdutoService : IProdutoService
    {

        private ecommerceEntities _db;

        public produto Delete(produto p)
        {
            using (_db = new ecommerceEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;//retira o proxy do banco

                _db.Set<produto>().Remove(p);
                _db.SaveChanges();
                return p;
            }
        }

        public produto DeleteId(int id)
        {
            using (_db = new ecommerceEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;//retira o proxy do banco
                produto p = _db.Set<produto>().Find(id);
                _db.Set<produto>().Remove(p);
                _db.SaveChanges();
                return p;
            }
        }

        public produto Find(int id)
        {
            using (_db = new ecommerceEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;//retira o proxy do banco
                produto p = _db.produto.Single(x => x.idProduto.Equals(id));
                return p;
            }
        }

        public List<produto> FindAll()
        {
            using (_db = new ecommerceEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;//retira o proxy do banco
                List<produto> p = _db.produto.Include("Cliente").ToList();
                return p;
            }
        }

        public produto New(produto p)
        {
            using (_db = new ecommerceEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;//retira o proxy do banco
                _db.produto.Add(p);
                _db.SaveChanges();
                return p;
            }
        }

        public produto Upadate(produto p)
        {
            using (_db = new ecommerceEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;//retira o proxy do banco
                _db.Entry(p).State = EntityState.Modified;
                _db.SaveChanges();
                return p;
            }
        }
    }
}
