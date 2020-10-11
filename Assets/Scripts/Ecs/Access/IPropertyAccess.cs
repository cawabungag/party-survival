namespace Ecs.Access
{
	public interface IPropertyAccess<in TObject, in TProperty>
	{
		void SetObjectValue(TObject obj, TProperty property);
		void SetPropertyValue(TObject obj, TProperty property);
		void Reset(TProperty property);
	}
}