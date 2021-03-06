﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Web.Routing;
    using Incoding.Extensions;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(IncControlBase))]
    public class When_inc_control_attr_attributes : Context_inc_control
    {
        #region Establish value

        static IncTextBoxControl<FakeModel, string> control;

        static IDictionary<string, object> attr;

        #endregion

        Establish establish = () =>
                              {
                                  control = new IncTextBoxControl<FakeModel, string>(mockHtmlHelper.Original, r => r.Prop);
                                  control.Attr(new { @class = "test", @checked = true });
                              };

        Because of = () => { attr = control.TryGetValue("attributes") as RouteValueDictionary; };

        It should_be_class = () => attr.ShouldBeKeyValue("class", "test");

        It should_be_checked = () => attr.ShouldBeKeyValue("checked", true);
    }
}