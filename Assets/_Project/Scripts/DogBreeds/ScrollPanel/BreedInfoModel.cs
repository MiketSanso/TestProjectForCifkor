namespace _Project.Scripts.DogBreeds
{
    public class BreedInfoModel
    {
        public BreedInfoResponse BreedInfo { get; private set; } = new BreedInfoResponse();

        public void SetBreedInfos(BreedInfoResponse breedInfo)
        {
            BreedInfo = breedInfo;
        }
    }
}