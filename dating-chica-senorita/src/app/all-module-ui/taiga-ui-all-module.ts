import { TuiDataList, TuiIcon, TuiRoot } from '@taiga-ui/core';
import { TuiButton, TuiTitle } from '@taiga-ui/core';
import { TuiAccordion, TuiSwitch, TuiTabs } from '@taiga-ui/kit';
import { TuiPlatform } from '@taiga-ui/cdk';
import {TuiAppBar, TuiNavigation} from '@taiga-ui/layout';
import { TuiTabBar } from '@taiga-ui/addon-mobile';


// TODO: вынести потом все используемые модули
export const TAIGA_UI_MODULES = [
  TuiRoot,
  TuiButton,
  TuiPlatform,
  TuiTitle,
  TuiSwitch,
  TuiIcon,
  ...TuiTabs,
  ...TuiDataList,
  ...TuiNavigation,
  ...TuiTabBar,
  ...TuiAppBar,
  ...TuiAccordion,
];
