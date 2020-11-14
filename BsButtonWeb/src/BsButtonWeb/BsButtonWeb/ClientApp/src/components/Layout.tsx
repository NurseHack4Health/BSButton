import * as React from 'react';
import {FC} from "react";
import {CssBaseline, Divider, Drawer, IconButton, List} from "@material-ui/core";
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import {makeStyles} from "@material-ui/core/styles";
import Header, {drawerWidth} from "./Header";
import clsx from "clsx";
import {mainListItems, secondaryListItems} from "./ListItems";
import {useSelector} from "react-redux";
import {selectRouterState} from "../store";

const useStyles = makeStyles((theme) => ({
  root: {
    display: 'flex',
  },
  drawerPaper: {
    position: 'relative',
    whiteSpace: 'nowrap',
    width: drawerWidth,
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  drawerPaperClose: {
    overflowX: 'hidden',
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    width: theme.spacing(7),
    [theme.breakpoints.up('sm')]: {
      width: theme.spacing(9),
    },
  },
  appBarSpacer: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    height: '100vh',
    overflow: 'auto',
  },
  toolbarIcon: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end',
    padding: '0 8px',
    ...theme.mixins.toolbar,
  },
}));


const Layout: FC = ({children}) => {
  const classes = useStyles();
  const [open, setOpen] = React.useState(false);
  const handleDrawerOpen = () => {
    setOpen(true);
  };
  const handleDrawerClose = () => {
    setOpen(false);
  };

  const {location: {pathname}} = useSelector(selectRouterState);

  return (
    <div className={classes.root}>
      <CssBaseline/>
      <Header onOpen={handleDrawerOpen} open={open}/>
      <Drawer
        variant="permanent"
        classes={{
          paper: clsx(classes.drawerPaper, !open && classes.drawerPaperClose),
        }}
        open={open}
      >
        <div className={classes.toolbarIcon}>
          <IconButton onClick={handleDrawerClose}>
            <ChevronLeftIcon/>
          </IconButton>
        </div>
        <Divider/>
        <List>{mainListItems(pathname)}</List>
        <Divider/>
        <List>{secondaryListItems(pathname)}</List>
      </Drawer>
      <main className={classes.content}>
        <div className={classes.appBarSpacer}/>
        {children}
      </main>
    </div>
  );
}

export default Layout;
