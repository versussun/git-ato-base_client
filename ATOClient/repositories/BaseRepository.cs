using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATOClient.model;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ATOClient.repositories;
using System.Data.Entity;

namespace ATOClient.repositories
{
    public class BaseRepository <T> : IRepositori<T> where T : class
    {
        public ObservableCollection<T> items { get; set; }
        public ModelEntities context;

        public BaseRepository()
        {
            context = SingletonContext.context;
            items = new ObservableCollection<T>(context.Set<T>());
            items.CollectionChanged += new NotifyCollectionChangedEventHandler(SaveChages);
        }

        private void SaveChages(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        T obj = e.NewItems[0] as T;
                        Add(obj);
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        T obj = e.OldItems[0] as T;
                        Delete(obj);
                        break;
                    }
            }
        }

        public void SaveChages()
        {
            context.ChangeTracker.DetectChanges();
            context.SaveChanges();
        }
        #region Operation
        public T Add(T obj)
        {
            try
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var es in ex.EntityValidationErrors)
                {
                    MessageBox.Show(es.ToString());
                }
                
            }
            return null;
        }

        public void Delete(T obj)
        {
            context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
        public T Create()
        {
           T newObj= context.Set<T>().Create();
           context.SaveChanges();
           return newObj;
        }
        public void Update(T obj)
        {
            var entity = obj as EntityObject;
            if (entity == null)
            {
                var attachedEntity = context.Set<T>().Find(entity.EntityKey);
                context.Entry(attachedEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }
        }

        #endregion Operation

        #region Queri
        public List<T> GetAll()
        {
            return context.Set<T>().ToList<T>();
            
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        #endregion Queri


    }
}
