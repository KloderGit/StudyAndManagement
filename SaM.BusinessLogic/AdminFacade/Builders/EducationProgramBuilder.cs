using Mapster;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Infrastructure;
using SaM.DataBases.Interfaces;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{

    public class EducationProgramDirector
    {
        IEducationBuilder builder;

        public EducationProgramDirector(IEducationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build()
        {
            builder.GetExistingItems();
            builder.GetNewItems();
            builder.Updated();
        }
    }

    public class EducationProgramBuilder : IEducationBuilder
    {

        IEnumerable<EducationProgramPOCO> serviceItems;
        List<EducationProgram> result = new List<EducationProgram>();

        List<EducationProgramPOCO> existItems = new List<EducationProgramPOCO>();
        List<EducationProgramPOCO> expextItems = new List<EducationProgramPOCO>();

        IEnumerable<Category> categories = new List<Category>();
        IEnumerable<EducationType> educationTypes = new List<EducationType>();

        public IUnitOfWorkEF database;

        public EducationProgramBuilder(IEnumerable<EducationProgramPOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }

        public void GetExistingItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);

            var databaseItemsGUIDs = database.EducationPrograms.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var shareGUIDs = seviceItemsGUIDS.Intersect(databaseItemsGUIDs);

            existItems.AddRange(serviceItems.Where(si => shareGUIDs.Contains(si.Guid)));
        }

        public void GetNewItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.EducationPrograms.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var differentGUIDs = seviceItemsGUIDS.Except(databaseItemsGUIDs);

            expextItems.AddRange(serviceItems.Where(si => differentGUIDs.Contains(si.Guid)));
        }


        public void UpdateCetegory()
        {
            var category = serviceItems.Select(pr => pr.Category)
                .Where(s => String.IsNullOrEmpty(s.Guid.ToString()) == false)
                                .GroupBy(x => x.Guid)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value);

            var categoryBuilder = new CategoryBuilder(category);
            var director = new CategoryDirector(categoryBuilder);

            director.Build();

            categories = categoryBuilder.GetResult();
        }

        public void UpdateEducationTypes()
        {
            var educationTypesItems = serviceItems.Select(pr => pr.EducationType)
                .Where(s => String.IsNullOrEmpty(s.Guid.ToString()) == false)
                                .GroupBy(x => x.Guid)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value);

            var educationTypeBuilder = new EducationTypeBuilder(educationTypesItems);
            var director = new EducationTypeDirector(educationTypeBuilder);

            director.Build();

            this.educationTypes = educationTypeBuilder.GetResult();
        }

        public void Updated()
        {

            UpdateCetegory();

            UpdateEducationTypes();

            var databaseItems = database.EducationPrograms.GetList().Where(dbItem => existItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList();

            foreach (var item in existItems)
            {
                var databaseItem = databaseItems.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);

                    databaseItem.CategoryId = categories.FirstOrDefault(c => c.Guid == item.Category.Guid).Id;
                    databaseItem.EducationTypeId = educationTypes.FirstOrDefault(t => t.Guid == item.EducationType.Guid).Id;

                    database.EducationPrograms.Update(databaseItem);
                }
            }

            foreach (var item in expextItems)
            {
                var databaseItem = item.Adapt<EducationProgram>();

                databaseItem.CategoryId = categories.FirstOrDefault( c => c.Guid == item.Category.Guid ).Id;
                databaseItem.EducationTypeId = educationTypes.FirstOrDefault(t => t.Guid == item.EducationType.Guid).Id;

                database.EducationPrograms.Add(databaseItem);
            }

            database.Save();

            result.AddRange(database.EducationPrograms.GetList()
                                    .Where(dbItem => serviceItems.Select(gd => gd.Guid)
                                    .Contains(dbItem.Guid))
                                    .IncludeMultiple( c => c.Category)
                                    .IncludeMultiple( t => t.EducationType) );
        }

        public IEnumerable<EducationProgram> GetResult()
        {
            return result;
        }
    }
}
