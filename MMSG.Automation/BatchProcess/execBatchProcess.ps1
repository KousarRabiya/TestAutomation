<#
.SYNOPSIS
    Executes batch process on a remote machine.
.DESCRIPTION
    Script can be run interactively prompting for input, or have parameters supplied for non-interactive execution
    The script will exit if the "batchParams" value is not supplied. In addition the "batchParams" value must be enclosed in quotes if any part of the value includes a hyphen "-",
    as this will interpret as an additional parameter for the script itself
.PARAMETER serverName
    Name of the remote server where the process is to be ran.
.PARAMETER batchName
    Name of the batch process to be exectued on the remote machine. Valid options are predifined in the paramters list.
    "CometBatch","REXXOnlineBatch","REXXBatch","ExpenseAutomationBatch"
.PARAMETER batchParams <required>
    Parameters to be passed to the executing batch process.
.EXAMPLE    
    .\execBatchProcess.ps1 -serverName msldevapp13 -batchName REXXOnlineBatch -batchParams "ProcessName=maxxiaonlineclaims -Caller=Comet_Online_Claims -email -SystemType=Comet"
    This will execute REXXOnlineBatchProcess.exe on the specified machine with the parameters "ProcessName=maxxiaonlineclaims -Caller=Comet_Online_Claims -email -SystemType=Comet"
.EXAMPLE
    .\execBatchProcess
    This will run the script interactively, and will prompt for each of the required parameters
.NOTES
    Author: Ben Clark
    Date:   October 10, 2017    
#>

param(
    [string]$serverName,
    [ValidateSet("CometBatch","REXXOnlineBatch","REXXBatch","ExpenseAutomationBatch")][string]$batchName,
    [string]$batchParams
)

    [int]$showSubMenu = 0
    $key = (3,4,2,3,56,34,254,222,1,1,2,23,42,54,33,233,1,34,2,7,6,5,35,43)

function Show-MainMenu
{
    param (
        [string]$Title = 'Batch Selection'
    )
    #cls
    write-host "================"$serverName.ToUpper()"================"
    Write-Host "================ $Title ================"
     
    Write-Host "1: Press '1' for Comet."
    Write-Host "2: Press '2' for REXXOnline."
    Write-Host "3: Press '3' for REXX."
    Write-Host "4: Press '4' for ExpenseAutomation."
    Write-Host "Q: Press 'Q' to quit."
}

#region submenus
function Show-CometSubMenu
{
    param (
        [string]$Title = "$batchName Parameter Selection"
    )
    cls
    Write-Host "================ $Title ================"
     
    Write-Host "0: Press '0' for 'None'"
    Write-Host "1: Press '1' for Comet param 1"
    write-host "M: Press 'M' to manually enter parameters"
    Write-Host "Q: Press 'Q' to quit."
}

function Show-REXXOnlineSubMenu
{
    param (
        [string]$Title = "$batchName Parameter Selection"
    )
    cls
    Write-Host "================ $Title ================"
     
    Write-Host "0: Press '0' for 'None'"
    Write-Host "1: Press '1' for REXX Online param 1"
    write-host "M: Press 'M' to manually enter parameters"
    Write-Host "Q: Press 'Q' to quit."
}

function Show-REXXSubMenu
{
    param (
        [string]$Title = "$batchName Parameter Selection"
    )
    cls
    Write-Host "================ $Title ================"
     
    Write-Host "0: Press '0' for 'None'"
    Write-Host "1: Press '1' for REXX param 1"
    write-host "M: Press 'M' to manually enter parameters"
    Write-Host "Q: Press 'Q' to quit."
}

function Show-ExpenseAutomationSubMenu
{
    param (
        [string]$Title = "$batchName Parameter Selection"
    )
    cls
    Write-Host "================ $Title ================"
     
    Write-Host "0: Press '0' for 'None'"
    Write-Host "1: Press '1' for Expense Automation param 1"
    write-host "M: Press 'M' to manually enter parameters"
    Write-Host "Q: Press 'Q' to quit."
}
#endregion

function CreatePSSession
{
    Write-Verbose "Setting up remote PowerShell session to server '$serverName'"

    # Create remote PowerShell session.
    $credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $userName,($password | ConvertTo-SecureString -Key $key)
    return New-PSSession -ComputerName $serverName -Credential $credential
}

$verboseMode = $VerbosePreference
if([string]::IsNullOrEmpty($serverName) -or [string]::IsNullOrEmpty($batchName)){# -or [string]::IsNullOrEmpty($batchParams)){
    $serverName = Read-Host "Enter server to run process on"

    Show-MainMenu
    $menu_input = Read-Host "Please make a selection"

}elseif($batchName -eq "CometBatch"){
    $menu_input = '1'
}elseif($batchName -eq "REXXOnlineBatch"){
    $menu_input = '2'
}elseif($batchName -eq "REXXBatch"){
    $menu_input = '3'
}elseif($batchName -eq "ExpenseAutomationBatch"){
    $menu_input = '4'
}


#region set process & runas credentials then display sub menu for batch parameters
switch ($menu_input)
{
    '1' {
        $batchName = "CometBatch"
        $cmd = "D:\Apps0\comet\Services\CometBatchProcesses\Maxxia.CometBatchProcesses.Console.exe"
        $userName = "msa\sa_cometservice"
        $password = "76492d1116743f0423413b16050a5345MgB8AG0AYwB0AFMASwBPAC8ARQBqAFMAcwBPAGcAYgB3AHAAcQBFAFMAdgA0AGcAPQA9AHwANgBhAGIAMgAxADIAOABjAGQAYQAzADYANwBjADgANgBkAGMAMQAzAGIAZgAyADEAMQAxADkAZABkADUANABkADUAYQBjADQAYQBlAGEANwBlADEAYwBkADIAOQAzADUANQBkADkAZgA3ADYAZAA3ADQAMQAyADYAOQA3ADEAMQA="
        if($showSubMenu -eq 1){Show-CometSubMenu; $submenu_input = Read-Host "Please make a selection"}
    } '2' {
        $batchName = "REXXOnlineBatch"
        $cmd = "D:\Apps0\RexxOnlineBatchProcesses\Maxxia.REXXOnlineBatchProcesses.Console.exe"
        $userName = "msa\sa_rexxonlinetest"
        $password = "76492d1116743f0423413b16050a5345MgB8AHAAYgAvAHAARgBuAFgAbABUAEkAagBmAFIAMgBIAFQAKwBHAGYANAAxAGcAPQA9AHwAMgBkADMANgA1ADcANQA3ADcANwA1AGIAMQAxAGUANAAxAGEAOAA1AGIAMgBlAGYAMgA3ADcAOQAwAGIAOABlAGQAZQAzAGIAYQBkADEAOQA2ADAAMAA0ADQAOAAwADQAZABhADAAZgA2ADkAZAAwADMANQA1AGUAZABjAGYAOQA="
        if($showSubMenu -eq 1){Show-REXXOnlineSubMenu; $REXXOnlineSubMenusubmenu_input = Read-Host "Please make a selection"}
    } '3' {
        $batchName = "REXXBatch"
        $cmd = "D:\Apps0\RexxBatchProcesses\Maxxia.REXXBatchProcesses.Console.exe"
        $userName = "msa\sa_rexxonlinetest"
        $password = "76492d1116743f0423413b16050a5345MgB8AHAAYgAvAHAARgBuAFgAbABUAEkAagBmAFIAMgBIAFQAKwBHAGYANAAxAGcAPQA9AHwAMgBkADMANgA1ADcANQA3ADcANwA1AGIAMQAxAGUANAAxAGEAOAA1AGIAMgBlAGYAMgA3ADcAOQAwAGIAOABlAGQAZQAzAGIAYQBkADEAOQA2ADAAMAA0ADQAOAAwADQAZABhADAAZgA2ADkAZAAwADMANQA1AGUAZABjAGYAOQA="
        if($showSubMenu -eq 1){Show-REXXSubMenu; $submenu_input = Read-Host "Please make a selection"}
    } '4' {
        $batchName = "ExpenseAutomationBatch"
        $cmd = "D:\Apps0\ExpenseAutomationBatch\ExpenseAutomationBatch.exe"
        $userName = "msa\sa_pcgbatchdev"
        $password = "76492d1116743f0423413b16050a5345MgB8AGMAZQBnAFEATgAvAHYANgBDADYAdAAxAHoAeQB4AFoAZgBxAEcASQBZAGcAPQA9AHwANQBlADUANQA1AGQAOABhAGQAYwAxADgAOQBlAGIAMAA2ADYAZgA2ADcANwA1ADMAMQBjADkANgAwADcANwBhADUAZgA2ADYAYgAwADgAMwA4AGQANQA2ADkAYQA2AGYAMAA0ADcANAA5AGEANgA4AGUAYQA2ADAAZAA5ADcANAA="
        if($showSubMenu -eq 1){Show-ExpenseAutomationSubMenu; $submenu_input = Read-Host "Please make a selection"}
    } 'q' {
        exit
    } default {
        "Invalid response"
        exit
    }
}
#endregion

#get batch parameters
$batchParams = Read-Host "Please enter required parameters"

#region code for sub-menus
if($showSubMenu -eq 1){
    if($batchName -eq "CometBatch"){     
        switch ($submenu_input)
        {
                   '0' {
                        $batchParams
                   }'1' {
                        $batchParams = "notepad.exe"
                   } 'M' {
                        $batchParams = Read-host "Please enter Parameters"
                   } 'q' {
                        exit
                   } default {
                        "Invalid response"
                        exit
                   }
             }
    }elseif($batchName -eq "REXXOnlineBatch"){
        switch ($submenu_input)
        {
                   '0' {
                        $batchParams
                   }'1' {
                        $batchParams = "notepad.exe"
                   } 'M' {
                        $batchParams = Read-host "Please enter Parameters"
                   } 'q' {
                        exit
                   } default {
                        "Invalid response"
                        exit
                   }
             }
    }elseif($batchName -eq "REXXBatch"){
        switch ($submenu_input)
        {
                   '0' {
                        $batchParams
                   }'1' {
                        $batchParams = "notepad.exe"
                   } 'M' {
                        $batchParams = Read-host "Please enter Parameters"
                   } 'q' {
                        exit
                   } default {
                        "Invalid response"
                        exit
                   }
             }
    }elseif($batchName -eq "ExpenseAutomationBatch"){
        switch ($submenu_input)
        {
                   '0' {
                        $batchParams
                   }'1' {
                        $batchParams = "notepad.exe"
                   } 'M' {
                        $batchParams = Read-host "Please enter Parameters"
                   } 'q' {
                        exit
                   } default {
                        "Invalid response"
                        exit
                   }
             }
    }
}
#endregion     

# Check for the server status
Write-Verbose "Checking status of server '$serverName'"
$validServer = Test-Connection -ComputerName $serverName -Count 2 -Quiet

if($validServer)
{
    Write-Verbose "Connection to server '$serverName' successfull."
    
    $session = CreatePSSession
    
    # Connect to remote server and execute PowerShell commands
    if([string]::IsNullOrEmpty($batchParams)){
        write-host "No parameters supplied... exiting"
        exit
    }else{
        write-host "Server:"$serverName.ToUpper()
        write-host "Executing:"$cmd
        write-host "Parameters:"$batchParams
        
        $ScriptBlockContent = {$proc = Start-Process $args[0] $args[1] -PassThru
            do{start-sleep -Milliseconds 500} 
            until($proc.HasExited)}

        Invoke-Command -Session $session -ScriptBlock $ScriptBlockContent -ArgumentList $cmd,$batchParams | Out-Null
    }
    Remove-PSSession -Name $session.Name
}
else
{
    Write-Verbose 'Unable to contact server. Server is offline or invalid server name.'
}
