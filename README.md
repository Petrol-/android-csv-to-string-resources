# android-csv-tostring-resources

This project is an utility app converting a CSV file to a strings.xml for Android.

## CSV file format

The file columns separator must be the character semicolon ;

Only the first 2 columns are used. If the file contains more than 2 columns, they are ignored.

The file must not have any header!

The first column is the key. The second, the value

exemple of CSV file (exemple.csv)
```
hello_key;Hello World !
cancel;Cancel
```

## output

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
  <string name="hello_key">"Hello World !"</string>
   <string name="cancel">"cancel"</string>
</resources>
```

## App usage (Windows)
```
AndroidToCSV.exe test.csv
```

The tool will create an output folder and generate the file strings.xml inside.


## Build from source

1. Download the sources
2. Open The solution in  src/
3. Right click on the project AndroidToCSV -> Publish
4. Select the Windows Profile (or create a new publushing profile)
5. This will generate a Self Contained App (it includes the .Net Core Runtime DLL) in bin/{Platform}/publish


