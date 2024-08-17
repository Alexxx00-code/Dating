import { TuiRoot } from '@taiga-ui/core';
import { TuiButton, TuiTitle } from '@taiga-ui/core';
import { TuiAccordion } from '@taiga-ui/kit';
import { TuiPlatform } from '@taiga-ui/cdk';
import { TuiAppBar } from '@taiga-ui/layout';
import { TuiTabBar } from '@taiga-ui/addon-mobile';

// TODO: вынести потом все используемые модули
export const TAIGA_UI_MODULES = [
  TuiRoot,
  TuiButton,
  TuiPlatform,
  TuiTitle,
  ...TuiTabBar,
  ...TuiAppBar,
  ...TuiAccordion,
];
