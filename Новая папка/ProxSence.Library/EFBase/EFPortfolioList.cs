using System.Collections.Generic;
using ProxSence.Library.ProxSenceModels;
using ProxSence.Library.InterfacesLibrary;
using System;

namespace ProxSence.Library.EFBase
{
    public class EFPortfolioList : IPortfolioAdding
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<PortfolioList> PList
        {
            get
            {
                return context.PList;
            }
        }

        public PortfolioList DeletePortfolioInformation(int Id)
        {
            PortfolioList dbEntry = context.PList.Find(Id);
            if (dbEntry != null)
            {
                context.PList.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SavePortfolioProject(PortfolioList PList)
        {
            if(PList.Id == 0)
            {
                context.PList.Add(PList);
            }
            else
            {
                PortfolioList dbEntry = context.PList.Find(PList.Id);
                if(dbEntry != null)
                {
                    dbEntry.ProjectName = PList.ProjectName;
                    dbEntry.Description = PList.Description;
                    dbEntry.ProjectCategory = dbEntry.ProjectCategory;
                    dbEntry.Images = dbEntry.Images;
                    dbEntry.ImageType = dbEntry.ImageType;
                }
            }
            context.SaveChanges();
        }
    }
}
