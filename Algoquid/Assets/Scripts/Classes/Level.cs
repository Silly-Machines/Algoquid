using System.Collections.Generic;

public class Level {
	public string name { get; set; }
	public string author { get; set; }
	public string difficulty { get; set; }
	public List<Element> elements { get; set; }

	public class Position
	{
		public int x { get; set; }
		public int z { get; set; }
	}
	
	public class Element
	{
		public string name { get; set; }
		public Position position { get; set; }
		public int rotation { get; set; }
	}
}
