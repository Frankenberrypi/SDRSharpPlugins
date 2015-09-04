using System;
using System.Xml.Serialization;
using System.IO;

namespace SDRSharp.LevelMeter
{
	/// <summary>
	/// Summary description for Options.
	/// </summary>
	public class Options
	{
    private  OptDat  Dat;
    string Path     = "";
    string Filename = "SDRSharp.LevelMeter.xml";
    string OptFile  = "";

    public Options(string OptionsPath)
    {
      Dat = new OptDat();
      Path = OptionsPath;

      OptFile = OptionsPath + "\\" + Filename;

      if (!File.Exists(OptFile))
      {
        Save();
      }
      Load();
    }

    #region Getter

    public int GaugeLevelMax
    {
      get
      {
        if (Dat.GaugeLevelMax > 0)
        {
          return 0;
        }
        return (Dat.GaugeLevelMax / 10) * 10;
      }
    }

    public int GaugeLevelMin
    {
      get
      {
        if (Dat.GaugeLevelMin < -140)
        {
          return -140;
        }
        return (Dat.GaugeLevelMin /10) * 10;
      }
    }

    public int Mode      
    {
        get
        {
          if (Dat.Mode > 2)
          {
            return 0;
          }
          return Dat.Mode;
        }
      set
      {
        Dat.Mode = value;
      }
    }

    public string Unit
    {
      get
      {
        if (Dat.Unit.Length > 4)
        {
          return Dat.Unit.Substring(0,4);
        }
        return Dat.Unit;
      }
      set
      {
        Dat.Unit = value;
      }
    }

    public bool ShowPopupOnStartup
    {
      get
      {
        return Dat.ShowPopupOnStartup;
      }
      set
      {
        Dat.ShowPopupOnStartup = value;
      }
    }

    public bool SMeterEnable
    {
      get
      {
        return Dat.SMeterEnable;
      }
      set 
      {
        Dat.SMeterEnable = value;
      }
    }
    #endregion

    #region Load/Save
    public void Load()
    {
      try
      {
        XmlSerializer s = new XmlSerializer(typeof(OptDat));
        TextReader r = new StreamReader(OptFile);
        this.Dat = (OptDat)s.Deserialize(r);
        r.Close();
      }
      catch(Exception ex)
      {
        
      }
      finally
      {
      }
    }

    public void Save()
    {
      XmlSerializer s = new XmlSerializer(typeof(OptDat));
      TextWriter w    = new StreamWriter(OptFile);
      s.Serialize(w, this.Dat);
      w.Close();
    }
    #endregion

  }

  
  public class OptDat
  {
    public string Unit        = "dB"; // dB, dBm, dBFS
    public bool SMeterEnable  = true;
    public bool ShowPopupOnStartup = false;
    public int Mode = 0;   /* 0=Peak Power VFO 1=Avg Power BW  2=Peak Power BW   */
    public int GaugeLevelMax = -0;
    public int GaugeLevelMin = -140;  
  }
}
