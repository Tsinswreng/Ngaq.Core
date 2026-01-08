using Tsinswreng.CsTools;

namespace Ngaq.Core.Tools.JsonMap;
public static class ExtnJsonMapItem{
	extension(UiJsonMapItem z){
		public bool TryGetNode(UiJsonMap Root, out IJsonNode R){
			var pathObj = JsonNode.ResolvePath(z.Path);
			return Root.Raw.TryGetNodeByPath(pathObj, out R);
		}
		public bool TryGetValue(UiJsonMap Root, out obj? R){
			R = default!;
			if(z.TryGetNode(Root, out var Node)){
				R = Node.ValueObj;
				return true;
			}
			return false;
		}
		public bool SetNode(UiJsonMap Root, IJsonNode Node){
			var pathObj = JsonNode.ResolvePath(z.Path);
			return Root.Raw.SetNodeByPath(pathObj, Node);
		}
		public bool SetValue(UiJsonMap Root, obj? Value){
			var pathObj = JsonNode.ResolvePath(z.Path);
			var Node = new JsonNode(Value);
			return Root.Raw.SetNodeByPath(pathObj, Node);
		}

	}
}
