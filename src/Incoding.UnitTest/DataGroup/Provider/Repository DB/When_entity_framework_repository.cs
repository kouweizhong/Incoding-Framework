﻿namespace Incoding.UnitTest
{
    #region << Using >>

    using Incoding.Data;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using NCrunch.Framework;

    #endregion

    [Subject(typeof(EntityFrameworkRepository)), Isolated]
    public class When_entity_framework_repository : Behavior_repository
    {
        #region Establish value

        protected static IRepository GetRepository()
        {
            var dbContext = new IncDbContext("IncRealEFDb", typeof(DbEntity).Assembly);
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = true;
            return new EntityFrameworkRepository(Pleasure.MockStrictAsObject<IEntityFrameworkSessionFactory>(mock => mock.Setup(r => r.GetCurrent()).Returns(dbContext)));
        }

        #endregion

        Behaves_like<Behavior_repository> should_be_behavior;

        Because of = () =>
                         {
                             repository = GetRepository();
                             repository.Init();
                         };
    }
}