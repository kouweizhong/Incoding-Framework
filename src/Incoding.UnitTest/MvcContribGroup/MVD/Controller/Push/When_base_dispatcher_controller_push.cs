﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib.MVD;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(DispatcherControllerBase))]
    public class When_base_dispatcher_controller_push : Context_dispatcher_controller
    {
        #region Establish value

        static FakeCommand command;

        #endregion

        Establish establish = () =>
                              {
                                  command = Pleasure.Generator.Invent<FakeCommand>();
                                  dispatcher.StubQuery(Pleasure.Generator.Invent<MVDExecute>(dsl => dsl.Tuning(r => r.Instance, new CommandComposite(command))), (object)Pleasure.Generator.String());
                                  dispatcher.StubQuery(Pleasure.Generator.Invent<CreateByTypeQuery.AsCommands>(dsl => dsl.Tuning(r => r.ModelState, controller.ModelState)
                                                                                                                         .Tuning(r => r.ControllerContext, controller.ControllerContext)
                                                                                                                         .Tuning(r => r.IsComposite, false)
                                                                                                                         .Tuning(r => r.IncTypes, typeof(FakeCommand).Name)), new CommandBase[] { command });
                                  dispatcher.StubQuery(Pleasure.Generator.Invent<GetMvdParameterQuery>(dsl => dsl.Tuning(r => r.Params, controller.HttpContext.Request.Params)), new GetMvdParameterQuery.Response()
                                                                                                                                                                                 {
                                                                                                                                                                                         Type = typeof(FakeCommand).Name
                                                                                                                                                                                 });
                              };

        Because of = () => { result = controller.Push(); };

        It should_be_result = () => result.ShouldBeIncodingSuccess();
    }
}