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
    keep:{},
    publicKeeps: [],
    
    vaults:[],
    vault:{},

    vaultKeeps:[],
    
    
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
      state.keeps = data ; // template
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data;
    }, 
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setVaults(state, data){
      state.vaults = data
    }, 
    setVault(state, data){
      state.vault = data
    }


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

      async getPublicKeeps({commit, dispatch}){
        try {
          let res = await api.get('keeps')
          commit('setPublicKeeps', res.data)
        } catch (error) {
          {console.log(error)}
        }
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
      }, 


    //#region VaultKeeps - getVaultKeeps, addVaultKeep, deleteVaultKeep

    createVault({commit, dispatch}, payload){
      api.post("vaults", payload)
      .then(res => {
        dispatch("getUserVaults")
      })
    }, 
    async getUserVaults({commit, dispatch}){
      try {
        let res = await api.get('vaults')
        commit('setVaults', res.data)
      }
      catch(error)
      {console.log(error)}
    },
    deleteVault({commit, dispatch}, payload){
      api.delete("vaults/" + payload)
      .then(res => {
        dispatch("getUserVaults")
      })
    },
    //#region Vault - getVaults, drawVault, createVault, deleteVault
    //userVault - enterVault and delete vault

    async getVault({commit, dispatch}, id){
      try {
        let res = await api.get('vaults/' + id)
        commit('setVault', res.data)
        router.push({name: "vault", params: {id: id}})
      }
      catch(error)
      {console.log(error)}
    },

    async getVaultKeeps({commit, dispatch}, id){
      try {
        let res = await api.get('vaultkeeps/' + id)
        commit('setVaultKeeps', res.data)
      }
      catch(error)
      {console.log(error)}
    }, 

    createVaultKeep({commit, dispatch}, payload){
        api.post('vaultkeeps', payload)
        dispatch('getVaultKeeps', payload.vaultId)
    }, 

    delVaultKeep({commit, dispatch}, payload){
      api.put('vaultKeeps', payload)
      dispatch('getVaultKeeps', payload.vaultId)
    }


  }
})
