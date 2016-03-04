using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public enum SelectEvent
    {
        FarmOrHunt,
        FacingLargePrey
    }

    public class OptionSelectData
    {
        public string Description { get; set; }
        public List<string> Options { get; set; }
        public string Selected { get; set; }
        public SelectEvent MyEvent { get; set; }
    }

    public interface OptionSelectDisplayer
    {
        void Display(OptionSelectData data);
    }
}
