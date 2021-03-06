using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using GitCommands;
using System.Windows.Forms;
using GitUI;

namespace GitPlugin
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
		}

		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
			_applicationObject = (DTE2)application;

            string fileName = _applicationObject.Solution.FileName;
			_addInInstance = (AddIn)addInInst;
			if(connectMode == ext_ConnectMode.ext_cm_UISetup)
			{
				object []contextGUIDS = new object[] { };
				Commands2 commands = (Commands2)_applicationObject.Commands;
				string toolsMenuName;

				try
				{
					//If you would like to move the command to a different menu, change the word "Tools" to the 
					//  English version of the menu. This code will take the culture, append on the name of the menu
					//  then add the command to that menu. You can find a list of all the top-level menus in the file
					//  CommandBar.resx.
					string resourceName;
					ResourceManager resourceManager = new ResourceManager("GitPlugin.CommandBar", Assembly.GetExecutingAssembly());
					CultureInfo cultureInfo = new CultureInfo(_applicationObject.LocaleID);
					
					if(cultureInfo.TwoLetterISOLanguageName == "zh")
					{
						System.Globalization.CultureInfo parentCultureInfo = cultureInfo.Parent;
						resourceName = String.Concat(parentCultureInfo.Name, "Tools");
					}
					else
					{
						resourceName = String.Concat(cultureInfo.TwoLetterISOLanguageName, "Tools");
					}
					toolsMenuName = resourceManager.GetString(resourceName);
				}
				catch
				{
					//We tried to find a localized version of the word Tools, but one was not found.
					//  Default to the en-US word, which may work for the current culture.
					toolsMenuName = "Tools";
				}

				//Place the command on the tools menu.
				//Find the MenuBar command bar, which is the top-level command bar holding all the main menu items:
				Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];
                Microsoft.VisualStudio.CommandBars.CommandBar taskListCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["Task List"];

                //Find the Tools command bar on the MenuBar command bar:
				CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
				CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;
                
                //This try/catch block can be duplicated if you wish to add multiple commands to be handled by your Add-in,
				//  just make sure you also update the QueryStatus/Exec method to include the new command names.
				try
				{
					//Add a command to the Commands collection:
                    Command command1 = commands.AddNamedCommand2(_addInInstance, "AddFiles", "Add files", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command2 = commands.AddNamedCommand2(_addInInstance, "Branch", "Create new branch", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command3 = commands.AddNamedCommand2(_addInInstance, "Browse", "Browse repository", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command4 = commands.AddNamedCommand2(_addInInstance, "Checkout", "Checkout branch", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command5 = commands.AddNamedCommand2(_addInInstance, "Clone", "Clone repository", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command6 = commands.AddNamedCommand2(_addInInstance, "Commit", "Commit changes", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command7 = commands.AddNamedCommand2(_addInInstance, "Diff", "View differences", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command8 = commands.AddNamedCommand2(_addInInstance, "Init", "Init new repository", "Executes the command for GitPlugin", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command9 = commands.AddNamedCommand2(_addInInstance, "Patch", "Apply patch", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command10 = commands.AddNamedCommand2(_addInInstance, "Pull", "Pull changes", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    Command command11 = commands.AddNamedCommand2(_addInInstance, "Push", "Push changes", "Executes the command for GitPlugin", true, 0, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);


					//Add a control for the command to the tools menu:
                    if ((command1 != null) && (command2 != null) && (command3 != null) && (command4 != null) &&
                        (command5 != null) && (command6 != null) && (command7 != null) && (toolsPopup != null))
					{
						command1.AddControl(toolsPopup.CommandBar, 1);
                        command2.AddControl(toolsPopup.CommandBar, 2);
                        command3.AddControl(toolsPopup.CommandBar, 3);
                        command4.AddControl(toolsPopup.CommandBar, 4);
                        command5.AddControl(toolsPopup.CommandBar, 5);
                        command6.AddControl(toolsPopup.CommandBar, 6);
                        command7.AddControl(toolsPopup.CommandBar, 7);
                        command8.AddControl(toolsPopup.CommandBar, 8);
                        command9.AddControl(toolsPopup.CommandBar, 9);
                        command10.AddControl(toolsPopup.CommandBar, 10);
                        command11.AddControl(toolsPopup.CommandBar, 11);
                       
					}
				}
				catch(System.ArgumentException)
				{
					//If we are here, then the exception is probably because a command with that name
					//  already exists. If so there is no need to recreate the command and we can 
                    //  safely ignore the exception.
				}
			}
		}

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		/// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
		/// <param term='commandName'>The name of the command to determine state for.</param>
		/// <param term='neededText'>Text that is needed for the command.</param>
		/// <param term='status'>The state of the command in the user interface.</param>
		/// <param term='commandText'>Text requested by the neededText parameter.</param>
		/// <seealso class='Exec' />
		public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
			if(neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
			{
				//if(commandName == "GitPlugin.Connect.Init")
				{
					status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported|vsCommandStatus.vsCommandStatusEnabled;
					return;
				}
			}
		}

		/// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
		/// <param term='commandName'>The name of the command to execute.</param>
		/// <param term='executeOption'>Describes how the command should be run.</param>
		/// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
		/// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
		/// <param term='handled'>Informs the caller if the command was handled or not.</param>
		/// <seealso class='Exec' />
		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
            try
            {
                //Settings.WorkingDir = 

                handled = false;
                string fileName = _applicationObject.Solution.FileName;
                Settings.WorkingDir = @"f:\Dev";//fileName.Substring(0, fileName.LastIndexOf('\\'));

                if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
                {

                    if (commandName == "GitPlugin.Connect.AddFiles")
                    {
                        FormAddFiles form = new FormAddFiles();
                        form.ShowDialog();
                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Branch")
                    {
                        FormBranch form = new FormBranch();
                        form.ShowDialog();

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Browse")
                    {
                        FormBrowse form = new FormBrowse();
                        form.ShowDialog();

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Checkout")
                    {
                        FormCheckout form = new FormCheckout();
                        form.ShowDialog();

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Clone")
                    {
                        FormClone form = new FormClone();
                        form.ShowDialog(); ;

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Commit")
                    {
                        FormCommit formCommit = new FormCommit();
                        formCommit.ShowDialog();

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Diff")
                    {
                        FormDiff formDiff = new FormDiff();
                        formDiff.ShowDialog();

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Init")
                    {
                        InitDto dto = new InitDto();
                        Init init = new Init(dto);
                        init.Execute();

                        MessageBox.Show(dto.Result);

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Patch")
                    {
                        MergePatch form = new MergePatch();
                        form.ShowDialog();
                        handled = true;
                        return;
                    } if (commandName == "GitPlugin.Connect.Pull")
                    {
                        FormPull form = new FormPull();
                        form.ShowDialog();

                        handled = true;
                        return;
                    }
                    if (commandName == "GitPlugin.Connect.Push")
                    {
                        FormPull form = new FormPull();
                        form.ShowDialog();
                        handled = true;
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
		}
		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}