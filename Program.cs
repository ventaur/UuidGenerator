// Decompiled with JetBrains decompiler
// Type: GuidGenerator.Program
// Assembly: GuidGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D01F6CC-86EF-46D3-A5C5-F256DCDE10DF
// Assembly location: C:\DigitalInstalls\GuidGenerator.exe

using System;
using System.Windows.Forms;

namespace GuidGenerator
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
