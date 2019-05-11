using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformListReference : GenericListReference<Transform, TransformListSO, TransformListReferenceBehaviour> {
    public TransformListReference(List<Transform> list) : base(list) {
    }

    public TransformListReference(TransformListSO reference) : base(reference) {
    }

    public TransformListReference(TransformListReferenceBehaviour reference) : base(reference) {
    }

    public TransformListReference(GenericListReference<Transform, TransformListSO, TransformListReferenceBehaviour> reference) : base(reference) {
    }
}

public class TransformListReferenceBehaviour : GenericListReferenceBehaviour<Transform, TransformListReference> { 
}

public class TransformListSO : RuntimeSet<Transform> {

}