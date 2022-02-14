Imports System
Imports System.IO
Imports System.Configuration
Imports System.IO.Compression

Module Module1
    Public Property baseDir As String
    Public Property workDir As String
    Public Property logFile As String
    Public Property tempDir As String

    Public Property archiveToNas As Boolean
    Sub Main()

        baseDir = ConfigurationManager.AppSettings("BaseDirectory")
        workDir = ConfigurationManager.AppSettings("WorkDirectory")
        logFile = String.Format("{0}{1}{2}.log", workDir, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString())

        archiveToNas = False
        If ConfigurationManager.AppSettings("archiveFiles").ToUpper() = "TRUE" Then archiveToNas = True

        LogResults("Base Directory: " + baseDir)
        LogResults("Working Directory: " + workDir)
        LogResults("Temp Directory: " + tempDir)
        For Each Dir As String In Directory.GetDirectories(baseDir)
            LogResults("Processing : " + Dir)

            Dim destination As String = Replace(Dir.ToUpper(), baseDir.ToUpper(), workDir.ToUpper())
            LogResults("Destination : " + destination)

            ArchiveDirectory(Dir, destination, destination)

        Next

    End Sub

    Sub LogResults(ByVal msg As String)
        Using fs As New StreamWriter(logFile, True)

            fs.WriteLine(DateTime.Now.ToString() + " : " + msg)

        End Using
    End Sub
    Sub ArchiveDirectory(ByVal source As String, ByVal destination As String, ByVal tempFolder As String)

        Dim directoryInfo As New DirectoryInfo(source)
        Dim sourceFolder As String = directoryInfo.Name

        Dim copyAndRemoveDirectories As Boolean = False
        If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings(sourceFolder)) Then
            If ConfigurationManager.AppSettings(sourceFolder) = "Skip" Then
                LogResults("Skipping")
                Return
            End If
            copyAndRemoveDirectories = True
        End If

        If copyAndRemoveDirectories Then
            If Directory.Exists(tempFolder) = True Then
                Try
                    Directory.Delete(tempFolder, True)
                Catch ex As Exception
                    LogResults("Failed to remove " + tempFolder)
                    LogResults(ex.Message)
                End Try
            End If

            If Directory.Exists(tempFolder) = False Then
                LogResults("Creating " + tempFolder)
                Directory.CreateDirectory(tempFolder)
            End If

        Else
            Try
                If File.Exists(destination + ".zip") Then File.Delete(destination + ".zip")

            Catch ex As Exception
                LogResults("Error Deleting Zip File")
                LogResults(ex.Message)
            End Try

        End If

        Dim fileToZip As String = destination + ".zip"
        Dim folderToZip As String = source

        If copyAndRemoveDirectories Then folderToZip = tempFolder

        LogResults("Folder to Zip: " + folderToZip)
        LogResults("Zip File: " + fileToZip)
        If copyAndRemoveDirectories Then

            LogResults("Starting to Copy Folders")
            Dim folderToExclude As String = source + "\" + ConfigurationManager.AppSettings(sourceFolder)

            Dim roboCopyCommand As String = "C:\windows\System32\robocopy.exe " & source & " " & tempFolder & " *.* /E /COPY:DAT /xd " + folderToExclude
            LogResults("Executing: " + roboCopyCommand)
            Shell(roboCopyCommand, AppWinStyle.NormalFocus, True)

            Dim folder As New mrmSiteFolder()
            folder.destination = destination
            folder.folderName = source
            folder.foldersToExclude = New List(Of String)()
            For Each Dir As String In Directory.GetDirectories(tempFolder)
                Dim di As New DirectoryInfo(Dir)
                Dim removeFolder As Boolean = False
                If Not String.IsNullOrEmpty(ConfigurationManager.AppSettings(sourceFolder.ToUpper() + "." + di.Name)) Then
                    LogResults("Folder: " + di.Name + " will be Removed.")
                    removeFolder = True
                End If
                If removeFolder = True Then
                    folder.foldersToExclude.Add(tempFolder + "\" + di.Name)
                End If

            Next

            For Each Dir As String In folder.foldersToExclude
                Try
                    LogResults("Removing: " + Dir)
                    Directory.Delete(Dir, True)
                Catch ex As Exception
                    LogResults("Failed to Delete " + Dir)
                    LogResults(ex.Message)
                End Try

            Next
        End If

        Try
            LogResults("Zipping Folder to File.")

            ZipFile.CreateFromDirectory(folderToZip, fileToZip, CompressionLevel.Optimal, False)
            LogResults("Finished Zipping Folder to File.")

        Catch ex As Exception
            LogResults("Error Zipping " + folderToZip)
            LogResults(ex.Message)
        End Try

        If copyAndRemoveDirectories Then

            Try
                LogResults("Cleaning Up")
                Directory.Delete(tempFolder, True)

            Catch ex As Exception
                LogResults("Error Cleaning UP ")
                LogResults(ex.Message)
            End Try

        End If

        If archiveToNas Then
            LogResults("Archiving to NAS")
            Dim previousArchiveDestination As String

            Dim archiveDestination As String
            archiveDestination = ConfigurationManager.AppSettings("archiveDestination")
            archiveDestination = Replace(archiveDestination, "[SERVERNAME]", Environment.MachineName)
            previousArchiveDestination = Replace(archiveDestination, "[SERVERNAME]", Environment.MachineName)
            archiveDestination = Replace(archiveDestination, "[DAYOFWEEK]", DateTime.Now.DayOfWeek.ToString())
            previousArchiveDestination = Replace(previousArchiveDestination, "[DAYOFWEEK]", "PreviousWeek\" + DateTime.Now.DayOfWeek.ToString())

            LogResults("Archive Destination: " + archiveDestination)
            If Directory.Exists(archiveDestination) = False Then
                Directory.CreateDirectory(archiveDestination)
            End If

            LogResults("Prior Archive Destination: " + previousArchiveDestination)
            If Directory.Exists(previousArchiveDestination) = False Then
                Directory.CreateDirectory(previousArchiveDestination)
            End If
            If File.Exists(previousArchiveDestination + sourceFolder + ".zip") Then
                LogResults("Moving Previous File " + sourceFolder + ".zip")
                File.Move(archiveDestination + sourceFolder + ".zip", previousArchiveDestination + sourceFolder + ".zip")
            End If

            LogResults("Copying")
            FileCopy(fileToZip, archiveDestination + sourceFolder + ".zip")
            LogResults("Deleting Zip File (Local Copy)")
            File.Delete(fileToZip)

        End If
    End Sub
End Module
