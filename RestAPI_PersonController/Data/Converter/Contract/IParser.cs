namespace Restapi_PersonController.Data.Converter.Contract
{
    public interface IParser<Origem, Destino>
    {
        Destino Parse(Origem origin);
        List<Destino> Parse(List<Origem> origin);
    }
}
