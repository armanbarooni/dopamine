; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "dopamineteam_food_app"
#define MyAppVersion "4.8"
#define MyAppPublisher "My Company, Inc."
#define MyAppURL "http://www.example.com/"
#define MyAppExeName "dopaminefood_app.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{3D37FACB-5A62-440D-AD14-537A8E9DFB1B}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Users\arman\Desktop
OutputBaseFilename=setup_v4.8
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\dopaminefood_app.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\arman.mrt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\armann.iss"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Bunifu.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Bunifu.UI.WinForms.BunifuButton.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Bunifu.UI.WinForms.BunifuDataGridView.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Bunifu.UI.WinForms.BunifuLabel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Bunifu_UI_v1.5.3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\ddfd.iss"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\di.iss"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\dopafood48.mdf"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\dopafood48_log.ldf"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\dopaminefood_app.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\final.mrt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\jk.iss"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\MobileCenterAbadan.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\MobileCenterAbadan.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Stimulsoft.Base.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Stimulsoft.Controls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Stimulsoft.Controls.Win.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Stimulsoft.Report.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Stimulsoft.Report.Win.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Telerik.WinControls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\Telerik.WinControls.UI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\TelerikCommon.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

