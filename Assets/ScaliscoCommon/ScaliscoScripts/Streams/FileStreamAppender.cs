using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileStreamAppender : StreamAppender {

    public StringReference fileName;

    public override void addToStream(string str) {
        string fullFilename = Application.persistentDataPath + Path.DirectorySeparatorChar
            + fileName.Value;

        Directory.CreateDirectory(Path.GetDirectoryName(fullFilename));
        File.AppendAllText(fullFilename, str + Environment.NewLine);
    }
}
