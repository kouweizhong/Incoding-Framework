﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System;
    using System.Linq.Expressions;
    using Incoding.MvcContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(IncHiddenControl<,>))]
    public class When_inc_horizontal_control_v3 : Context_inc_control
    {
        #region Establish value

        static IncHorizontalControl<IncHiddenControl<FakeModel, object>> control;

        #endregion

        Establish establish = () =>
                              {
                                  IncodingHtmlHelper.BootstrapVersion = BootstrapOfVersion.v3;
                                  Expression<Func<FakeModel, object>> expression = model => model.Prop;
                                  var label = new IncLabelControl(mockHtmlHelper.Original, expression);
                                  var input = new IncHiddenControl<FakeModel, object>(mockHtmlHelper.Original, expression);
                                  var validation = new IncValidationControl(mockHtmlHelper.Original, expression);
                                  control = new IncHorizontalControl<IncHiddenControl<FakeModel, object>>(label, input, validation);
                                  control.LabelOffset = Offset.Col_xs_5;
                                  control.InputOffset = Offset.Col_xs_7;
                                  control.GroupOffset = Offset.Col_md_12;
                              };

        Because of = () => { result = control.ToHtmlString(); };

        It should_be_render = () => result.ToString()
                                          .ShouldEqual("<div class=\"form-group col-md-12\"><label class=\"control-label col-xs-5\" for=\"Prop\">Prop</label><div class=\"col-xs-7\"><input class=\"form-control\" id=\"Prop\" name=\"Prop\" type=\"hidden\" value=\"TheSameString\" /></div></div>");

        Cleanup clean = () => IncodingHtmlHelper.BootstrapVersion = BootstrapOfVersion.v2;
    }
}