<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCLeftSideBar.ascx.cs" Inherits="Players_PlayerUserControls_UCLeftSideBar" %>

<div class="navbar-default sidebar" role="navigation">
    <div class="sidebar-nav navbar-collapse">
        <ul class="nav" id="side-menu">
            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="/Players/Dashboard/">
                    <i class="fa fa-fw fa-dashboard"></i>
                    <span class="nav-link-text">Dashboard</span>
                </a>
            </li>
            <li class="nav-item" data-toggle="tooltip" data-placement="right" title="">
                <a class="nav-link" href="/Players/Event/">
                    <i class="fa fa-fw fa-diamond"></i>
                    <span class="nav-link-text">Join Tournament</span>
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
