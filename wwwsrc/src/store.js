import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)
//Allows axios to work locally or live
let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    publicKeep: [],


    vaults:[],
    vault:{}
    
    // boards: [],
    // lists: [],
    // tasks: {},
    // activeUser: {},
    // activeList: [],
    // activeTask: [],
    // activeBoard: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, data) {
      state.keeps = data ; // Follow this template for vaults and remaining keeps
    },
    setVaultKeep(state, data) {

    }, 
    setpublicKeep(state, data) {

    },
    setuserKeep(state, data){

    }, 



  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#region Keeps - getUserKeep, createUKeep, deleteUKeep, updateUKeep, 
    
      async getUserKeeps({commit, dispatch}){
        try {
          let res = await api.get('keeps/user')
          commit('setKeeps', res.data)
        }
        catch(error)
        {console.log(error)}
      },

      createKeep({commit, dispatch}, payload){
        api.post("keeps", payload)
        .then(res => {
          dispatch("getUserKeeps")
        })
      }, 

      deleteKeep({commit, dispatch}, payload){
        api.delete("keeps/" + payload)
        .then(res => {
          dispatch("getUserKeeps")
        })
      }


    //#region VaultKeeps - getVaultKeeps, addVaultKeep, deleteVaultKeep


    //#region Vault - getVaults, drawVault, createVault, deleteVault

    
  }
})

