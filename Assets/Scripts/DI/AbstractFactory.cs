namespace Services
{
    public abstract class AbstractFactory<T>
    {
        public T Instantiate()
        {
            var target = InstantiateObject();
            ServiceInjector.Inject(target);
            return target;
        }

        protected abstract T InstantiateObject();
    }
}