namespace SIM.Core.Commands
{
  using System;
  using System.Linq;
  using Sitecore.Diagnostics.Base;
  using SIM.Core.Common;
  using SIM.Instances;

  public class StateCommand : AbstractInstanceActionCommand<string>
  {
    protected override void DoExecute(CommandResult<string> result)
    {
      Assert.ArgumentNotNull(result, nameof(result));

      var name = Name;
      Assert.ArgumentNotNullOrEmpty(name, nameof(name));

      InstanceManager.Initialize();
      var instance = InstanceManager.Instances.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
      Ensure.IsNotNull(instance, "instance is not found");

      result.Data = instance.State.ToString();
    }
  }
}