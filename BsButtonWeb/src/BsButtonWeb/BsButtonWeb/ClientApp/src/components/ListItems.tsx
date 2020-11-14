import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import SportsIcon from '@material-ui/icons/Sports';
import ListSubheader from '@material-ui/core/ListSubheader';
import DashboardIcon from '@material-ui/icons/Dashboard';
import {
  CloudUpload,
  Favorite,
  GifTwoTone,
  RecordVoiceOver,
  ShortText,
  Assignment,
  QuestionAnswer, Help
} from "@material-ui/icons";
import {SvgIconTypeMap} from "@material-ui/core";
import {OverridableComponent} from "@material-ui/core/OverridableComponent";
import {Link} from 'react-router-dom';
import Dashboard from "./Dashboard";
import About from "./About";

interface RouteDefinition {
  route: string;
  name: string;
  icon: OverridableComponent<SvgIconTypeMap>;
  routeComponent: React.FunctionComponent;
  extraRouteProps: { [prop: string]: any }
}

export const MainLocations: RouteDefinition[] = [
  {name: 'Dashboard', icon: DashboardIcon, route: '/', routeComponent: Dashboard, extraRouteProps: {exact: true}},
  {name: 'Report', icon: SportsIcon, route: '/report', routeComponent: Dashboard, extraRouteProps: {exact: true}},
  {name: 'About', icon: Help, route: '/about', routeComponent: About, extraRouteProps: {}},
  // {name: 'Categorization', icon: Assignment, route: '/character/definition', routeComponent: CharacterSources, extraRouteProps: {}},
]

export const SecondaryLocations: RouteDefinition[] = [
  // {name: 'Visual', icon: GifTwoTone, route: '/asset/type/visual', routeComponent: Todo, extraRouteProps: {}},
  // {name: 'Audio', icon: RecordVoiceOver, route: '/asset/type/audio', routeComponent: Todo, extraRouteProps: {}},
  // {name: 'Text ', icon: ShortText, route: '/asset/type/text', routeComponent: Todo, extraRouteProps: {}},
]

const buildListItems = (routeDefinitions: RouteDefinition[], currentRoute: string) =>
  (
    routeDefinitions.map(routeDef => (
      <Link key={routeDef.name} style={{
        textDecoration: 'none', color: 'inherit',
      }} to={routeDef.route}>
        <ListItem button selected={currentRoute === routeDef.route}>
          <ListItemIcon>
            <routeDef.icon/>
          </ListItemIcon>
          <ListItemText primary={routeDef.name}/>
        </ListItem>
      </Link>
    ))
  );

export const mainListItems = (currentRoute: string): JSX.Element => (
  <div>
    {
      buildListItems(MainLocations, currentRoute)
    }
  </div>
);

export const secondaryListItems = (currentRoute: string): JSX.Element => (
  <div>
    {
      buildListItems(SecondaryLocations, currentRoute)
    }
  </div>
);
