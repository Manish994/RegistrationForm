
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: 'list', component: () => import('pages/Index.vue') },
      { path: 'addstudentdetails', component: () => import('pages/addStudentDetails.vue') }
    ]
  },
  {
    path: '/',
    component: () => import('layouts/LoginReg.vue'),
    children: [
      { path: 'auth/login', component: () => import('pages/user/Login.vue') },
      { path: 'auth/register', component: () => import('pages/user/Register.vue') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
