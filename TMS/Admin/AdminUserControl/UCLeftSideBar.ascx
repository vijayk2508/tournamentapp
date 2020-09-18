<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCLeftSideBar.ascx.cs" Inherits="Admin_AdminUserControl_UCLeftSideBar" %>


<div class="navbar-default sidebar" role="navigation">
    <div class="sidebar-nav navbar-collapse">
        <ul class="nav" id="side-menu">

            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="#">
                    <i class="fa fa-fw fa-dashboard"></i>
                    <span class="nav-link-text">Dashboard</span>
                </a>
            </li>

            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="#">
                    <i class="fa fa-fw  fa-user-plus"></i>
                    <span class="nav-link-text">Manage User's</span>
                </a>
            </li>

            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="#">
                    <i class="fa fa-fw  fa-user-plus"></i>
                    <span class="nav-link-text">Manage Comment's</span>
                </a>
            </li>

            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="#">
                    <i class="fa fa-fw fa-edit"></i>
                    <span class="nav-link-text">Manage Blog's</span>
                </a>
            </li>

             <li>
                <a href="#">
                    <i class="fa fa-fw fa-wpforms"></i>
                    <span class="nav-link-text">User</span>
                    <span class="fa arrow"></span>
                </a>

                <ul class="nav nav-second-level">
                    <li><a href="#">Top Header</a></li>
                </ul>
            </li>

            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="#">
                    <i class="fa fa-fw fa-wrench"></i>
                    <span class="nav-link-text">Account Setting</span>
                </a>
            </li>

        </ul>
	</div>
    <!-- /.sidebar-collapse -->
	<button type="button" id="btnToggle2" class="slide-bar-button-2 pull-right hidden-xs">
     <i id="sidebar-icon" class="fa fa-arrow-left"></i>      
     <!--span class="f-bar">
      <span></span>
       <span class="middle-span"></span>
       <span></span>
      </span-->			
    </button>
</div>
