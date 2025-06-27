using System;
using System.Collections.Generic;

[Serializable]
public class BreedInfoResponse {
    public List<BreedItem> data;
}

[Serializable]
public class BreedItem {
    public string id;
    public string type;
    public BreedName attributes;
}

[Serializable]
public class BreedName {
    public string name;
}