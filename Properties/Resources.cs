// Decompiled with JetBrains decompiler
// Type: GuidGenerator.Properties.Resources
// Assembly: GuidGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D01F6CC-86EF-46D3-A5C5-F256DCDE10DF
// Assembly location: C:\DigitalInstalls\GuidGenerator.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GuidGenerator.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) GuidGenerator.Properties.Resources.resourceMan, (object) null))
          GuidGenerator.Properties.Resources.resourceMan = new ResourceManager("GuidGenerator.Properties.Resources", typeof (GuidGenerator.Properties.Resources).Assembly);
        return GuidGenerator.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => GuidGenerator.Properties.Resources.resourceCulture;
      set => GuidGenerator.Properties.Resources.resourceCulture = value;
    }
  }
}
