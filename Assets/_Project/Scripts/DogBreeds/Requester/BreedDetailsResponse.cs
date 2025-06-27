using System;

[Serializable]
public class BreedDetailsResponse {
    public BreedDetailData data;
}

[Serializable]
public class BreedDetailData {
    public BreedDetailAttributes attributes;
}

[Serializable]
public class BreedDetailAttributes {
    public string name;
    public string description;
}