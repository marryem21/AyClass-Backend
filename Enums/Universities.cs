using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace ayclass_backend.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Universities
    {
        UniversiteDeTunis,
        UniversiteDeTunisElManar,
        UniversiteDeMannouba,
        UniversiteDeCarthdage,
        UniversiteDeEzZitouna,
        UniversiteDeSousse,
        UniversiteDeMonastir,
        UniversiteDeSfax,
        UniversiteDeJandouba,
        UniversiteDeKairouan,
        UniversiteDeGafsa,
        UniversiteDeGabes,
        directionGénéraleDesEtuDesTechnologiques,
        UniversitePrivee

    }
}