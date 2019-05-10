using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We inherit from StringVarible only because we want to treat this like SV. 
// StringVAriable is deprected and needs to be migrated to use this only.
public class StringReferenceBehaviour : StringVariable {

    public StringReference reference;

    public override string Value {
        get { return reference.Value; }
        set { reference.setValue(value); }
    }

    public override void set(StringVariable variable) {
        reference.setValue(variable.Value);
    }

    public void set(StringReferenceBehaviour variable) {
        reference.setValue(variable.Value);
    }

}
