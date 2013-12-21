﻿namespace Incoding.SiteTest.Controllers
{
    #region << Using >>

    using System;
    using Incoding.MvcContrib.MVD;

    #endregion

    public class DispatcherController : DispatcherControllerBase
    {
        #region Constructors

        public DispatcherController()
                : base(AppDomain.CurrentDomain.GetAssemblies()) { }

        #endregion
    }
}